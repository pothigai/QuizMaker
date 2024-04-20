using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class UserInterface
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
        public void printOutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string scanInputString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public int scanInputInteger(string message)
        {
            int output = 0;
            string input = "";

            while (true)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
                else
                {
                    int.TryParse(input, out output);
                    break;
                }
            }
            return output;
        }
        public bool scanInputBool(string message)
        {
            bool output = false;
            string input = "";

            while (true)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (!bool.TryParse(input, out output))
                {
                    Console.WriteLine("Invalid input, please enter true or false.");
                }
                else
                {
                    bool.TryParse(input, out output);
                    break;
                }
            }
            return output;
        }
        public char scanInputChar(string message)
        {
            char output;
            string input = "";
            while (!char.TryParse(input, out output))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (!char.TryParse(input, out output))
                {
                    Console.WriteLine("Invalid input, please enter a character.");
                }
            }
            return char.ToLower(output);
        }
    }
}
