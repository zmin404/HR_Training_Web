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
    
    public partial class tbl_CourseTopicStory
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TopicId { get; set; }
        public Nullable<int> StoryId { get; set; }
    
        public virtual tbl_Course tbl_Course { get; set; }
        public virtual tbl_Story tbl_Story { get; set; }
        public virtual tbl_Topic tbl_Topic { get; set; }
        public IList<string> SelectedQuestion { get; set; }

        public tbl_CourseTopicStory()
        {
            SelectedQuestion = new List<string>();
        }


    }
}
