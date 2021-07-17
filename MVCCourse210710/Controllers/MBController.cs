using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse210710.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MB1()
        {
            var data = "Hello World";
            ViewData.Model = data;
            return View(data);
        }
        public ActionResult MB2()
        {
            var data = "Hello World";
            ViewData["data"]= data;
            return View("MB1");
        }
        public ActionResult MB3()
        {
            ViewBag.data = "Hello World";
            return View("MB1");
        }
        public ActionResult MB4()
        {
            TempData["data"] = "Hello World";
            return RedirectToAction("MB2");
        }
        public ActionResult MB5()
        {
            Session["SessionData"] = "Hello World";
            return View("MB1");
        }
    }
}