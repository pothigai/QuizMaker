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
            Console.WriteLine($"(1) {Options[0]}\t (2) {Options[1]}\r\n(3) {Options[2]}\t\t (4) {Options[3]}");
        }
    }
}
