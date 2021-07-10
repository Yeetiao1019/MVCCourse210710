using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCourse210710.ViewModels
{
    public class CourseCreate
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}