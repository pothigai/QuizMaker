using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the quiz maker");

            var QuestionList = new List<QandA>();
            UserInterface UI = new UserInterface();
            QuestionListLogic QLL = new QuestionListLogic();

            char choice = UI.scanInputChar("Do you want to play (p) or build (b) or exit (x)?");

            if (choice == Constants.BUILD)
            {
                int numQuestions = UI.scanInputInteger("How many questions do you want to add?");

                for (int q = 0; q < numQuestions; q++)
                {
                    QuestionList.Add(UI.CreateQuestion());
                }
                QLL.CreateXmlFile(QuestionList, Constants.PATH);
            }
            else if (choice == Constants.PLAY)
            {
                int points = 0;

                QuestionList = QLL.ReadXmlFile(Constants.PATH);

                foreach (var question in QuestionList)
                {
                    UI.PresentQuestion(question, new List<int>());
                    List<int> choices = UI.GetChoices(question.CorrectAnswers);
                    points += QLL.AddPoints(question, choices);
                    Console.WriteLine("Total points:");
                    Console.WriteLine(points);
                }
            }
            else if (choice == Constants.EXIT)
            {
                Console.WriteLine("Exiting.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose 'p' to play, 'b' to build, or 'x' to exit.");
            }
        }

    }
}

