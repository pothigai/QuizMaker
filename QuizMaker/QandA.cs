﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QandA
    {
        public static UserInterface UI = new UserInterface();

        public string Question { get; set; }
        public bool MultipleAnswers { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswers { get; set; }
        public string[] Answer { get; set; }

    }
}
