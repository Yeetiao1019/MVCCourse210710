using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse210710.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult VR1()
        {
            return View();
        }
        public ActionResult VR2()
        {
            return View("VR1");     //跑VR1的頁面
        }
        public ActionResult VR3()
        {

            return View("VR1", "_Layout2");     //只用指定的頁面與指定的模板
        }
    }
}