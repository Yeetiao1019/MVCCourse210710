using MVCCourse210710.ValidationAttributes;
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

        public ActionResult PVR1()
        {

            return PartialView();       //只顯示PVR1.cshtml的內容，不包 _Layout2.cshtml 與C#程式
        }

        public ActionResult Robots()
        {

            return PartialView();
        }

        public ActionResult FRView()
        {

            return View();
        }

        public ActionResult FR1(bool isDownload = false)
        {
            return File(Server.MapPath("~/Content/dotnet.png"), "image/png");
        }

        public ActionResult FR2()
        {
            return File(Server.MapPath(     //定義下載檔案的MIME與檔名
                "~/Content/dotnet.png"),
                "image/png",
                "MicrosoftdotNet.jpg");
        }
        [ContentType("text/xml")]
        public ActionResult GetXML()
        {
            return PartialView();
        }
    }
}