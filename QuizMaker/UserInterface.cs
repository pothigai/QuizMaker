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
        public void PrintQuestion(string message)
        {
            Console.WriteLine($"Question: {message}");
        }
        public void PrintOptions(List<string> Options)
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"({i + 1}){Options[i]}");
            }
        }
        public void PrintOutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ScanInputString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public int ScanInputInteger(string message)
        {
            int output;
            while (true)
            {
                string input = GetInput(message);
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
        public bool ScanInputBool(string message)
        {
            bool output;
            while (true)
            {
                string input = GetInput(message);
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
        public char ScanInputChar(string message)
        {
            char output;
            while (true)
            {
                string input = GetInput(message);
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

            newQuestion.Question = ScanInputString("Enter the question:");
            newQuestion.MultipleAnswers = ScanInputBool("Does this question have multiple answers? (true/false)");

            newQuestion.Options = GetOptions();
            newQuestion.CorrectAnswers = GetCorrectAnswers(newQuestion.Options);

            newQuestion.Answer = GetCorrectAnswer(newQuestion.Options, newQuestion.CorrectAnswers);

            return newQuestion;
        }
        public List<string> GetOptions()
        {
            int numOptions = ScanInputInteger("How many options does this question have?");
            List<string> options = new List<string>();

            for (int o = 0; o < numOptions; o++)
            {
                options.Add(ScanInputString($"Enter option {o + 1}:").ToLower());
            }

            return options;
        }

        public int GetCorrectAnswers(List<string> options)
        {
            if (ScanInputBool("Does this question have multiple correct answers? (true/false)"))
            {
                Console.WriteLine("How many correct answers does this question have?");
                return ScanInputInteger("Enter the number of correct answers:");
            }
            else
            {
                return 1;
            }
        }

        public string[] GetCorrectAnswer(List<string> options, int correctAnswers)
        {
            string[] answers = new string[correctAnswers];

            for (int a = 0; a < correctAnswers; a++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter correct answer {a + 1}:");
                    string answer = Console.ReadLine().ToLower();
                    if (!options.Contains(answer))
                    {
                        Console.WriteLine("Please make sure your entry matches the options.");
                    }
                    else
                    {
                        answers[a] = answer;
                        break;
                    }
                }
            }
            return answers;
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
            PrintQuestion(question.Question);
            PrintOptions(question.Options);

            Console.WriteLine("You've chosen:");
            foreach (int choice in choices)
            {
                Console.WriteLine(question.Options[choice - 1]);
            }
        }
        public void AddQuestion(List<QandA> QuestionList)
        {
            int numQuestions = ScanInputInteger("How many questions do you want to add?");
            for (int q = 0; q < numQuestions; q++)
            {
                QuestionList.Add(CreateQuestion());
            }
        }
    }
}
