using System;

namespace HR_Training.Models.VO
{
    public class QuestionVO
    {
        public int ID { get; set; }
        public Nullable<bool> IsCorrect { get; set; }
        public string Answer { get; set; }


    }
}