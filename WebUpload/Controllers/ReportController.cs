using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUpload.Controllers
{
    public class ReportController : Controller
    {
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
    }
}