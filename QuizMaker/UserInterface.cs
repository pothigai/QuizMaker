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
        QuestionListLogic QLL = new QuestionListLogic();
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
        public string getInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public int scanInputInteger(string message)
        {
            int output;
            while (true)
            {
                string input = getInput(message);
                if (int.TryParse(input, out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return output;
        }
        public bool scanInputBool(string message)
        {
            bool output;
            while (true)
            {
                string input = getInput(message);
                if (bool.TryParse(input, out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter true or false.");
                }
            }
            return output;
        }
        public char scanInputChar(string message)
        {
            char output;
            while (true)
            {
                string input = getInput(message);
                if (char.TryParse(input, out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a character.");
                }
            }
            return char.ToLower(output);
        }
    public QandA CreateQuestion()
        {
            var newQuestion = new QandA();

            newQuestion.Question = scanInputString("Enter the question:");

            newQuestion.MultipleAnswers = scanInputBool("Does this question have multiple answers? (true/false)");

            int numOptions = scanInputInteger("How many options does this question have?");
            newQuestion.Options = new List<string>();

            for (int o = 0; o < numOptions; o++)
            {
                newQuestion.Options.Add(scanInputString($"Enter option {o + 1}:").ToLower());
            }

            if (newQuestion.MultipleAnswers)
            {
                Console.WriteLine("How many correct answers does this question have?");
                newQuestion.CorrectAnswers = int.Parse(Console.ReadLine());
            }
            else
            {
                newQuestion.CorrectAnswers = 1;
            }
            newQuestion.Answer = new string[newQuestion.CorrectAnswers];

            for (int a = 0; a < newQuestion.CorrectAnswers; a++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter correct answer {a + 1}:");
                    newQuestion.Answer[a] = Console.ReadLine().ToLower();
                    if (!newQuestion.Options.Contains(newQuestion.Answer[a]))
                    {
                        Console.WriteLine("Please make sure your entry matches the options.");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return newQuestion;
        }
        public List<int> GetChoices(int numberOfAnswers)
        {
            Console.WriteLine("Enter your option");

            List<int> choices = new List<int>();

            for (int i = 0; i < numberOfAnswers; i++)
            {
                choices.Add(int.Parse(Console.ReadLine()));
            }

            return choices;
        }
        public void PresentQuestion(QandA question, List<int> choices)
        {
            printQuestion(question.Question);
            printOptions(question.Options);

            Console.WriteLine("You've chosen:");
            foreach (int choice in choices)
            {
                Console.WriteLine(question.Options[choice - 1]);
            }
        }
        public void addQuestion(List<QandA> QuestionList)
        {
            int numQuestions = scanInputInteger("How many questions do you want to add?");
            for (int q = 0; q < numQuestions; q++)
            {
                QuestionList.Add(CreateQuestion());
            }
        }
    }
}
