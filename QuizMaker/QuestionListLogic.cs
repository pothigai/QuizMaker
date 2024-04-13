using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QuestionListLogic
    {
        public static UserInterface UI = new UserInterface();
        public QandA CreateQuestion()
        {
            var newQuestion = new QandA();

            newQuestion.Question = UI.scanInputString("Enter the question:");

            newQuestion.MultipleAnswers = UI.scanInputBool("Does this question have multiple answers? (true/false)");

            int numOptions = UI.scanInputInteger("How many options does this question have?");
            newQuestion.Options = new List<string>();

            for (int o = 0; o < numOptions; o++)
            {
                newQuestion.Options.Add(UI.scanInputString($"Enter option {o + 1}:"));
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
                Console.WriteLine($"Enter correct answer {a + 1}:");
                newQuestion.Answer[a] = Console.ReadLine();
            }

            return newQuestion;
        }
        public int PresentQuestion(QandA question)
        {
            UserInterface UI = new UserInterface();
            int score = 0;
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
                score = 0;
            }
            else
            {
                Console.WriteLine("Correct!");
                score = 1;
            }
            return score;
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
