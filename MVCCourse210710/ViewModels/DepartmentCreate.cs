using MVCCourse210710.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourse210710.ViewModels
{
    [MetadataType(typeof(DepartmentCreateMetaData))]
    public class DepartmentCreate
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}