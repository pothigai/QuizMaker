using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class Format
    {
        public void printQuestion(string message)
        {
            Console.WriteLine($"Question: {message}");
        }

        public void printOptions(List<string> Options)
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"({i + 1}){Options[i]}");
            }
        }
    }
}
