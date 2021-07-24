using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse210710.ViewModels
{
    public class CourseCreate
    {
        public string Title { get; set; }
        public MVCCourse210710.Models.Credits Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}