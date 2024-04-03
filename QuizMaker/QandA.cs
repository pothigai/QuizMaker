using System;
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

        public static QandA CreateQuestion()
        {
            var newQuestion = new QandA();

            newQuestion.Question = UI.scanInputString("Enter the question:");
            Console.WriteLine("Enter the question:");

            newQuestion.MultipleAnswers = UI.scanInputBool("Does this question have multiple answers? (true/false)");

            int numOptions = UI.scanInputInteger("How many options does this question have?");
            newQuestion.Options = new List<string>();

            for (int o = 0; o < numOptions; o++)
            {
                newQuestion.Options.Add(UI.scanInputString($"Enter option {o + 1}:"));
            }

            if (newQuestion.MultipleAnswers)
            {
                newQuestion.CorrectAnswers = UI.scanInputInteger("How many correct answers does this question have?");
            }
            else
            {
                newQuestion.CorrectAnswers = 1;
            }
            newQuestion.Answer = new string[newQuestion.CorrectAnswers];

            for (int a = 0; a < newQuestion.CorrectAnswers; a++)
            {
                newQuestion.Answer[a] = UI.scanInputString($"Enter correct answer {a + 1}:");
            }

            return newQuestion;
        }

        public static void PresentQuestion(QandA question)
        {
            UserInterface UI = new UserInterface();

            UI.printQuestion(question.Question);
            UI.printOptions(question.Options);

            List<int> choices = GetChoices(question.CorrectAnswers);

            Console.WriteLine("You've chosen:");
            foreach (int choice in choices)
            {
                Console.WriteLine(question.Options[choice - 1]);
            }

            bool[] results = EvaluateAnswers(question, choices);

            Console.WriteLine("Result:");
            if (results.Contains(false))
            {
                Console.WriteLine("Wrong.");
            }
            else
            {
                Console.WriteLine("Correct!");
            }
        }

        static List<int> GetChoices(int numberOfAnswers)
        {
            Console.WriteLine("Enter your option");

            List<int> choices = new List<int>();

            for (int i = 0; i < numberOfAnswers; i++)
            {
                choices.Add(int.Parse(Console.ReadLine()));
            }

            return choices;
        }

        static bool[] EvaluateAnswers(QandA question, List<int> choices)
        {
            bool[] results = new bool[question.CorrectAnswers];

            for (int i = 0; i < choices.Count; i++)
            {
                if (question.Answer.Contains(question.Options[choices[i] - 1]))
                {
                    results[i] = true;
                }
                else
                {
                    results[i] = false;
                }
            }

            return results;
        }
    }
}
