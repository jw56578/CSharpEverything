using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.TeamFoundation.Framework.Client;
using System.IO;
using System.Collections.Generic;

namespace TFSClient.Test
{
    [TestClass]
    public class TFSClientTests
    {

        [TestMethod]
        public void TFSClientCanConnectToServer()
        {
            // Replace with your setup
            var tfsServer = @"http://tfs.freshbeginnings.corp:8080/tfs";
            var serverPath = @"$/";

            Uri tfsUri =  new Uri(tfsServer);

            TfsConfigurationServer configurationServer =
                TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);

            // Get the catalog of team project collections
            ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(
                new[] { CatalogResourceTypes.ProjectCollection },
                false, CatalogQueryOptions.None);

            // List the team project collections
            //foreach (CatalogNode collectionNode in collectionNodes)
            //{
            //    DoStuffForSpecificCatalog(configurationServer,collectionNode);
            //}
            DoStuffForSpecificCatalog(configurationServer, collectionNodes[1]);
        }

        void DoStuffForSpecificCatalog(TfsConfigurationServer configurationServer,CatalogNode collectionNode)
        {
            // Use the InstanceId property to get the team project collection
            Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
            TfsTeamProjectCollection teamProjectCollection = configurationServer.GetTeamProjectCollection(collectionId);
            GetChangesets(teamProjectCollection);
            // Print the name of the team project collection
            Console.WriteLine("Collection: " + teamProjectCollection.Name);

            // Get a catalog of team projects for the collection
            ReadOnlyCollection<CatalogNode> projectNodes = collectionNode.QueryChildren(
                new[] { CatalogResourceTypes.TeamProject },
                false, CatalogQueryOptions.None);

            // List the team projects in the collection
            foreach (CatalogNode projectNode in projectNodes)
            {
                Console.WriteLine(" Team Project: " + projectNode.Resource.DisplayName);
            }

        }
        void GetChangesets(TfsTeamProjectCollection tfs)
        {
            //why the freak is this not working
            var dtpFrom = DateTime.Parse("2/17/1016");
            var dtpTo = DateTime.Parse("3/3/2016");
            //search by date range 
            VersionSpec fromDateVersion = new DateVersionSpec(dtpFrom);
            VersionSpec toDateVersion = new DateVersionSpec(dtpTo);


            ChangesetVersionSpec versionFrom = new
                           ChangesetVersionSpec(223416);
            ChangesetVersionSpec versionTo = new
                          ChangesetVersionSpec(225981);
            
            
            //this gets that most recent 100 change sets
            var history =
                tfs
                .GetService<VersionControlServer>()
                .QueryHistory(
                    path: "$/eLeadCRM Project/Evolution2/Evolution2Web",
                    version: VersionSpec.Latest,
                    deletionId: 0,
                    recursion: RecursionType.Full,
                    user: String.Empty,
                    versionFrom: versionFrom,
                    versionTo: versionTo, //VersionSpec.Latest,
                    maxCount: 5555,
                    includeChanges: true,
                    slotMode: true);
            List<string> asyncFiles = new List<string>();

            foreach (Changeset changeset in history)
            {
                foreach (var w in changeset.Changes)
                {
                    try
                    {
                        //where are there items that aren't files that can't be downloaded
                        if (w.Item.ServerItem.Contains(".js") || w.Item.ServerItem.Contains(".css") || w.Item.ServerItem.Contains(".asp"))
                            continue;
                        var stream = w.Item.DownloadFile();
                        StreamReader reader = new StreamReader(stream);
                        string text = reader.ReadToEnd().ToLower();
                        if (text.Contains("async") &&! w.Item.ServerItem.Contains(".js"))
                        {
                            asyncFiles.Add(w.Item.ServerItem);
                        }
                    }
                    catch 
                    {
                    }
                    finally {

                    }

                    Console.WriteLine("Type:" + w.ChangeType);
                    Console.WriteLine("Comment:" + changeset.Comment);
                    Console.WriteLine("Date:" + changeset.CreationDate);

                    foreach (var y in changeset.WorkItems)
                    {
                        Console.WriteLine("Name:" + y.Title + y.Type);
                    }
                }
            }
        }
        [TestMethod]
        public void TFSClientCanRetrieveChangesets()
        {

        }
    }
}
