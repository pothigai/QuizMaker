using System.Reflection.Metadata.Ecma335;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the quiz maker");

            var QuestionList = new List<QandA>();

            Console.WriteLine("How many questions do you want to add?");
            int numQuestions = int.Parse(Console.ReadLine());

            for (int q = 0; q < numQuestions; q++)
            {
                QuestionList.Add(QandA.CreateQuestion());
            }

            Format UI = new Format();

            foreach (var question in QuestionList)
            {
                QandA.PresentQuestion(question);
            }

        }
    }
}

