using MVCCourse210710.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse210710.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ContosoUniversityEntities db = new ContosoUniversityEntities();
        protected override void HandleUnknownAction(string actionName)
        {
            this.RedirectToAction("Index", new { actionName }).ExecuteResult(this.ControllerContext);
        }

#if DEBUG
        public ActionResult CustomDebug()
        {
            return View();
        }
    }
#endif
}