using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Training.Models.VO
{
    public class CourseTopicStoryVO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TopicId { get; set; }
        public Nullable<int> StoryId { get; set; }

        public virtual tbl_Course tbl_Course { get; set; }
        public virtual tbl_Story tbl_Story { get; set; }
        public virtual tbl_Topic tbl_Topic { get; set; }

        //public List<string> SelectedQuestion { get; set; }
        public IList<string> SelectedQuestion { get; set; }

        public CourseTopicStoryVO()
        {
            SelectedQuestion = new List<string>();
        }
    }
}