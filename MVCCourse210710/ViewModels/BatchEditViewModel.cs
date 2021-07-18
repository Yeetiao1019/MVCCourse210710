using MVCCourse210710.DataAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourse210710.ViewModels
{
    public class BatchEditViewModel
    {
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [Budget]
        public decimal Budget { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
    }
}