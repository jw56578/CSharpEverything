using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Tests.Star.GM;

namespace WebService.Tests
{
    public static partial class Functions
    {
        public static Header CreateHeader(Header header,string action, string manifestElement)
        {
            header.Action = action;
            var p = header.PayloadManifest = new PayloadManifest();
            var m = p.Manifest = new Manifest();
            m.ContentID = "Content0";
            m.Element = manifestElement;
            m.NamespaceURI = "http://www.gm.com/vls";
            m.Version = "1.0";

            var s = header.Security = new Security();
            var ut = s.UsernameToken = new UsernameToken();
            ut.Password = new Password();
            ut.Password.Text = "Password123";
            ut.Username = "A38772_EI";

            var ts = s.Timestamp = new Timestamp();
            ts.Created = DateTime.UtcNow.ToString("o");
            ts.Expires = DateTime.UtcNow.AddMinutes(1).ToString("o");
            return header;
        }
        public static Header CreateHeader(Header header)
        {
            return CreateHeader(header, "LocateVehicle", "ExtGetVehicleInventory");

        }
    }
}
