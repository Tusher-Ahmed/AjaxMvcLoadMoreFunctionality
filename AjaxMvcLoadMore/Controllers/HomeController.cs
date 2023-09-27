using AjaxMvcLoadMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvcLoadMore.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonEntities _db;
        public HomeController()
        {
              _db = new PersonEntities();
        }
        public ActionResult Index()
        {
            int num = 5;
            Session["data"] = num;
            var data=_db.People.Take(num).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(Person p)
        {
            int rows =Convert.ToInt32( Session["data"]) + 5;
            var data=_db.People.Take(rows).ToList();
            Session["data"] = rows;
            return PartialView("_Person", data);
        }

       
    }
}