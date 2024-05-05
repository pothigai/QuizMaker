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

            bool validChoice = false;

            while (!validChoice)
            {
                char choice = UI.scanInputChar($"Do you want to play ({Constants.PLAY}) or build ({Constants.BUILD}) or exit ({Constants.EXIT})?");

                if (choice == Constants.BUILD)
                {
                    UI.addQuestion(QuestionList);
                    QLL.CreateXmlFile(QuestionList, Constants.PATH);
                    validChoice = true;
                }
                if (choice == Constants.PLAY)
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
                    validChoice = true;
                }
                if (choice == Constants.EXIT)
                {
                    Console.WriteLine("Exiting.");
                    validChoice = true;
                }
                if (QLL.InvalidCheck(choice))
                {
                    Console.WriteLine("Invalid choice. Please choose 'p' to play, 'b' to build, or 'x' to exit.");
                }
            }
        }

    }
}

