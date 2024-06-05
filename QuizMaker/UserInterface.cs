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

        public string[] GetCorrectAnswer(List<string> options)
        {
            Console.WriteLine("Enter correct answer(s) separated by commas:");
            string answerString = Console.ReadLine().ToLower();
            int numberOfAnswers = answerString.Count(c => c == Constants.COMMA) + 1;
            
            Console.WriteLine($"You entered {numberOfAnswers} answer(s).");

            string[] answers = answerString.Split(Constants.COMMA);
            foreach (var answer in answers)
            {
                if (!options.Contains(answer.Trim()))
                {
                    Console.WriteLine($"'{answer}' is not a valid option. Please enter correct options.");
                    return GetCorrectAnswer(options);
                }
            }
            return answers.Select(a => a.Trim()).ToArray();
        }

        public List<int> GetChoices(int numberOfAnswers)
        {
            Console.WriteLine("Enter your option(s) separated by commas:");

            List<int> choices = new List<int>();

            string input = Console.ReadLine();
            string[] inputs = input.Split(Constants.COMMA);
            foreach (var choice in inputs)
            {
                choices.Add(int.Parse(choice.Trim()));
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
                var newQuestion = new QandA();

                newQuestion.Question = ScanInputString("Enter the question:");
                newQuestion.Options = GetOptions();
                newQuestion.Answer = GetCorrectAnswer(newQuestion.Options);

                QuestionList.Add(newQuestion);
            }
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
        public void PrintResult(int score)
        {
            Console.WriteLine("Result:");
            if (score == 0)
            {
                Console.WriteLine("Wrong.");
            }
            else
            {
                Console.WriteLine("Correct!");
            }
        }
    }
}
