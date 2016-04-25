using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Web.api;

namespace Web
{
    /// <summary>
    /// Summary description for index
    /// https://gugiaji.wordpress.com/2015/07/04/creating-custom-asp-net-web-api-using-handler-ashx-also-example-on-using-it-with-jquery-and-webrequest/
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var segs = context.Request.Url.Segments;
            var controller = "";
            var action = "";
            var parameter = "";
            for (int i = 0; i < segs.Length; i ++) {
                if (String.Equals(segs[i], "index.ashx/", StringComparison.OrdinalIgnoreCase))
                {
                    controller = segs.Length > i + 1 ? segs[i + 1].Replace("/",""): "";
                    action = segs.Length > i + 2 ? segs[i + 2].Replace("/","") : "";
                    parameter = segs.Length > i + 3 ? segs[i + 3].Replace("/","") : "";
                    break;
                }
            }

            var result = new Resolver().Resolve(controller, action, parameter);
            var json = GetJSON(result);
            context.Response.Write(json);

        }

        string GetJSON(object obj)
        {
            var js = new JavaScriptSerializer();
            var json = js.Serialize(obj);
            return json;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}