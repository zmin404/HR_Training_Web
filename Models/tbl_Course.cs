//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_Training.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Course()
        {
            this.tbl_CompanyAndCourse = new HashSet<tbl_CompanyAndCourse>();
            this.tbl_CourseTopicStory = new HashSet<tbl_CourseTopicStory>();
            this.tbl_EmployeeCourse = new HashSet<tbl_EmployeeCourse>();
            this.tbl_TrainingProgress = new HashSet<tbl_TrainingProgress>();
            this.tbl_ProgressTransaction = new HashSet<tbl_ProgressTransaction>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LastModifiedBy { get; set; }
        public System.DateTime LastModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CompanyAndCourse> tbl_CompanyAndCourse { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CourseTopicStory> tbl_CourseTopicStory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_EmployeeCourse> tbl_EmployeeCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_TrainingProgress> tbl_TrainingProgress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ProgressTransaction> tbl_ProgressTransaction { get; set; }
    }
}