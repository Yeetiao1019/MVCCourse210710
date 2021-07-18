using MVCCourse210710.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse210710.ActionFilterAttributes
{
    public class PersonSelectListForViewByViewBag : ActionFilterAttribute
    {
        PersonRepository repo = RepositoryHelper.GetPersonRepository();

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if(filterContext.Result is ViewResultBase)
            {
                filterContext.Controller.ViewBag.InstuctorID = new SelectList(repo.GetPersonSelect(),"Value","Text");
            }

            base.OnResultExecuting(filterContext);
        }
    }
}