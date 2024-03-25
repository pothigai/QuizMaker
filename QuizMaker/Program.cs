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

            var Question1 = new QandA { Question = "What color is the sky?", MultipleAnswers = false, Options = new List<string> { "Green", "Blue", "Red", "Yellow" }, CorrectAnswers = 1 };
            Question1.Answer = new string[Question1.CorrectAnswers];
            Question1.Answer[0] = "Blue";

            var Question2 = new QandA { Question = "Which of these are pets?", MultipleAnswers = true, Options = new List<String> { "Dog", "Cat", "Whale", "Lion" }, CorrectAnswers = 2 };
            Question2.Answer = new string[Question2.CorrectAnswers];
            Question2.Answer[0] = "Dog";
            Question2.Answer[1] = "Cat";

            int count = QuestionList.Count;
            Format UI = new Format();

            UI.printQuestion(Question1.Question);
            UI.printOptions(Question1.Options);

            Console.WriteLine("Enter your option");
            int choice = int.Parse(Console.ReadLine());
            if (Question1.Options[choice - 1] == Question1.Answer[0])
            {
                Console.WriteLine("Correct answer!");
            }
            else
            {
                Console.WriteLine("Wrong answer.");
            }

        }
    }
}

