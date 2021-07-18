using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse210710.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ContentTypeAttribute : ActionFilterAttribute
    {
        public ContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
        public string ContentType { get; private set; }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.ContentType = ContentType;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.ContentType = ContentType;
        }

    }
}