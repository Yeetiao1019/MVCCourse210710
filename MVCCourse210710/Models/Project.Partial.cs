namespace MVCCourse210710.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project
    {
    }
    
    public partial class ProjectMetaData
    {
        [Required]
        public long SerialNO { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ProjectName { get; set; }
    }
}
