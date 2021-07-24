namespace MVCCourse210710.Models
{
    using MVCCourse210710.DataAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HasDirtyWords(Name))
            {
                yield return new ValidationResult("名稱不能包含髒話", new string[] { "Name" });
            }
        }

        private bool HasDirtyWords(string name)
        {
            if (name.Contains("fxxx"))
            {
                return true;
            }
            return false;
        }
    }

    public partial class DepartmentMetaData
    {
        [Required]
        [UIHint("DepartmentID")]
        public int DepartmentID { get; set; }
        [Required]
        [DisplayName("部門名稱")]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        //[Range(0, 100, ErrorMessage = "請輸入合理的預算範圍 ({1},{2})")]
        [BudgetAttribute]
        public decimal Budget { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        [Required]
        [UIHint("InstructorID")]
        public Nullable<int> InstructorID { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual Person Manager { get; set; }
    }
    [MetadataType(typeof(DepartmentCreateMetaData))]
    public partial class DepartmentCreateMetaData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        //[Range(0, 100, ErrorMessage = "請輸入合理的預算範圍 ({1},{2})")]
        [BudgetAttribute]
        public decimal Budget { get; set; }
        [UIHint("InstructorID")]        //改成下拉選單
        public Nullable<int> InstructorID { get; set; }
    }
    [MetadataType(typeof(DepartmentEditMetaData))]
    public partial class DepartmentEditMetaData
    {
        [Required]
        [UIHint("DepartmentID")]
        public int DepartmentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "請輸入合理的預算範圍 ({1},{2})")]
        public decimal Budget { get; set; }
        [UIHint("InstructorID")]
        public Nullable<int> InstructorID { get; set; }
    }
}
