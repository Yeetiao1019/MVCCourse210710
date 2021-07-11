using MVCCourse210710.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace MVCCourse210710.Controllers
{
    public class DeptController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();
        // GET: Dept
        public DeptController()
        {
            db.Database.Log = (msg) => Debug.WriteLine(msg);        //在偵錯時將EF做了甚麼操作列在輸出視窗
        }
        public ActionResult Index()
        {
            return View(db.Department.Include(d => d.Manager));
        }
    }
}