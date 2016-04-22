using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Tests.Star.GM;
using System.Collections.Generic;

namespace WebService.Tests
{
    [TestClass]
    public class StarTests
    {
        [TestMethod]
        public void CanSearchInventory()
        {
            /*
            i have no idea what id is for searching a specific dealer
            ive changed the BAC and dealer number id and the results are always the same

             the username and password appear to definately by the credentials of 
             ut.Password.Text = "Password123";
             ut.Username = "A38772_EI";

            when i put a bad trading partner id in, it does not affect anything
            when i put a bad BAC it does not affect anything
            */
            List<string> vendorIds = new List<string>() {
"115275",
"166558",
"227245",
"165842",
"245881",
"277892",
"189801",
"189904",
"186063",
"204395",
"216983",
"115461",
"116376",
"112990",
"114146",
"114323",
"208227",
"285155",
"117532",
"113730",
"222219",
"263160",
"114307",
"246814",
"115085",
"113783",
"117512",
"112265",
"287568",
"165235",
"287903",
"116596",
"172791",
"165710",
"163999",
"112245",
"167046",
"151650",
"220108",
"207362",
"268032",
"256690",
"114061",
"279728",
"285135",
"114876",
"272670",
"199963",
"168523",
"111942",
"115903",
"184306",
"168823",
"118176",
"204076",
"117196"};


            var gm = new GMStarImplementation("999970");
            var sr = new Star.StarRequest(gm);

            foreach (var id in vendorIds)
            {
                sr.SearchCompanyInventory(id);
            }
        }
    }
}
