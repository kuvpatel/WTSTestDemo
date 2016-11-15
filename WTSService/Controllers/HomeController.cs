using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTSService.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        // called from EmployeeData view
        [HttpGet]
        public ActionResult GetMonthList()
        {

            List<MonthItem> list = new List<MonthItem>();
            list.Add(new MonthItem { ID = 1, Name = "Jan" });
            list.Add(new MonthItem { ID = 2, Name = "Feb" });
            list.Add(new MonthItem { ID = 3, Name = "Mar" });
            list.Add(new MonthItem { ID = 4, Name = "Apr" });
            list.Add(new MonthItem { ID = 5, Name = "May" });
            list.Add(new MonthItem { ID = 6, Name = "Jun" });
            list.Add(new MonthItem { ID = 7, Name = "Jul" });
            list.Add(new MonthItem { ID = 8, Name = "Aug" });
            list.Add(new MonthItem { ID = 9, Name = "Sep" });
            list.Add(new MonthItem { ID = 10, Name = "Oct" });
            list.Add(new MonthItem { ID = 11, Name = "Nov" });
            list.Add(new MonthItem { ID = 12, Name = "Dec" });

            return Json(new { result = list }, JsonRequestBehavior.AllowGet);
        }

    }


    public class MonthItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


}
