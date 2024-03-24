using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QandA
    {
        public string Question { get; set; }
        public bool MultipleAnswers { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectAnswers { get; set; }
        public string[] Answer { get; set; }
    }
}
