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

            var Question1 = new QandA { Question = "What color is the sky?", MultipleAnswers = false, Option1 = "Green", Option2 = "Blue", Option3 = "Yellow", Option4 = "Red", CorrectAnswers = 1 };
            Question1.Answer = new string[Question1.CorrectAnswers];
            Question1.Answer[0] = "Blue";

            var Question2 = new QandA { Question = "Which of these are pets?", MultipleAnswers = true, Option1 = "Dog", Option2 = "Cat", Option3 = "Lion", Option4 = "Whale", CorrectAnswers = 2 };
            Question2.Answer = new string[Question2.CorrectAnswers];
            Question2.Answer[0] = "Dog";
            Question2.Answer[1] = "Cat";

            int count = QuestionList.Count;
            string[] Options = new string[4];
            Format UI = new Format();

            //while (display && count > 0)
            //{
            //    UI.printQuestion(Question1.Question);
            //    UI.printOptions(Question1.Option1, Question1.Option2, Question1.Option3, Question1.Option4);
            //}
            UI.printQuestion(Question1.Question);
            Options = UI.printOptions(Question1.Option1, Question1.Option2, Question1.Option3, Question1.Option4);



            Console.WriteLine("Enter your option");
            int choice = int.Parse(Console.ReadLine());
            if (Options[choice-1] == Question1.Answer[0])
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

