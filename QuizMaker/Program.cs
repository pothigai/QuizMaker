using System.Reflection.Metadata.Ecma335;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the quiz maker");

            var QuestionList = new List<QandA>();
            bool display = true;

            Console.WriteLine("How many questions do you want to add?");
            int numQuestions = int.Parse(Console.ReadLine());

            for (int q = 0; q < numQuestions; q++)
            {
                var newQuestion = new QandA();

                Console.WriteLine("Enter the question:");
                newQuestion.Question = Console.ReadLine();

                Console.WriteLine("Does this question have multiple answers? (true/false)");
                newQuestion.MultipleAnswers = bool.Parse(Console.ReadLine());

                Console.WriteLine("How many options does this question have?");
                int numOptions = int.Parse(Console.ReadLine());
                newQuestion.Options = new List<string>();

                for (int o = 0; o < numOptions; o++)
                {
                    Console.WriteLine($"Enter option {o + 1}:");
                    newQuestion.Options.Add(Console.ReadLine());
                }

                Console.WriteLine("How many correct answers does this question have?");
                newQuestion.CorrectAnswers = int.Parse(Console.ReadLine());
                newQuestion.Answer = new string[newQuestion.CorrectAnswers];

                for (int a = 0; a < newQuestion.CorrectAnswers; a++)
                {
                    Console.WriteLine($"Enter correct answer {a + 1}:");
                    newQuestion.Answer[a] = Console.ReadLine();
                }

                QuestionList.Add(newQuestion);
            }

            Format UI = new Format();

            foreach (var question in QuestionList)
            {
                UI.printQuestion(question.Question);
                UI.printOptions(question.Options);

                Console.WriteLine("Enter your option");

                List<int> choices = new List<int>();

                for (int i = 0; i < question.Answer.Length; i++)
                {
                    choices.Add(int.Parse(Console.ReadLine()));
                }

                Console.WriteLine("You've chosen:");

                for (int i = 0; i < question.Answer.Length; i++)
                {
                    Console.WriteLine(question.Options[choices[i] - 1]);
                }

                bool[] flag = new bool[question.Answer.Length];

                for (int i = 0; i < choices.Count; i++)
                {
                    if (question.Answer.Contains(question.Options[choices[i] - 1]))
                    {
                        flag[i] = true;
                    }
                    else
                    {
                        flag[i] = false;
                    }
                }

                Console.WriteLine("Result:");

                if (flag.Contains(false))
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
}

