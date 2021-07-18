using System;
using System.Web.Mvc;

namespace MVCCourse210710.ActionFilterAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class ContentTypeAttribute : ActionFilterAttribute
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