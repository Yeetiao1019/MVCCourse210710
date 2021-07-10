using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourse210710.ViewModels
{
    public class DepartmentCreate
    {
        [Required(ErrorMessage = "請輸入您的中文姓名")]
        public string Name { get; set; }

        [Range(0, 10, ErrorMessage = "請輸入正確的預算範圍({1} ~ {2})")]
        public decimal Budget { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}