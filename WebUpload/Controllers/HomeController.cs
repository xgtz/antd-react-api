using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Samples()
        {
            DataTable dt = new DataTable();
            string[] columns = { "key", "name", "age", "address" };
            columns.ToList().ForEach(x =>
            {
                dt.Columns.Add(x);
            });

            DataRow dr = dt.NewRow();
            dr["key"] = "1";
            dr["name"] = "张三";
            dr["age"] = "15";
            dr["address"] = "酡颜斫柴";

            dt.Rows.Add(dr);

            string strJsonResult = JsonConvert.SerializeObject(new { result = dt });
            return Content(strJsonResult, "text/json");
        }

        [HttpPost]
        public ActionResult Upload()
        {
            string StorageRoot = @"E:\Workspace\MyTest\React\WebUpload\files";
            DataTable dtFiles = new DataTable();
            var userName = Request.Form["username"];
            Console.WriteLine(userName);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));
                file.SaveAs(fullPath);
            }
            //foreach (string file in Request.Files) 
            //{
            //    var headers = Request.Headers;
            //    var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file));
            //}

            string strJsonResult = JsonConvert.SerializeObject(dtFiles);
            return Content(strJsonResult, "text/json");
        }
    }
}