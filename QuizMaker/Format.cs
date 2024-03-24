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

        public string[] printOptions(string Option1, string Option2, string Option3, string Option4)
        {
            string[] Options = new string[4];

            Options[0] = Option1;
            Options[1] = Option2;
            Options[2] = Option3;
            Options[3] = Option4;

            Console.WriteLine($"(1) {Option1}\t (2) {Option2} \r\n(3) {Option3}\t (4) {Option4}");
            return Options;
        }
    }
}
