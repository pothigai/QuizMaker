using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var QuestionList = new List<QandA>();
            UserInterface ui = new UserInterface();
            QuestionListLogic logic = new QuestionListLogic();

            ui.PrintOutputMessage("Welcome to the quiz maker");

            bool validChoice = false;

            while (!validChoice)
            {
                char choice = ui.ScanInputChar($"Do you want to play ({Constants.PLAY}) or build ({Constants.BUILD}) or exit ({Constants.EXIT})?");

                if (choice == Constants.BUILD)
                {
                    ui.AddQuestion(QuestionList);
                    logic.CreateXmlFile(QuestionList);
                    validChoice = true;
                }
                if (choice == Constants.PLAY)
                {
                    int points = 0;
                    QuestionList = logic.ReadXmlFile();
                    foreach (var question in QuestionList)
                    {
                        ui.PresentQuestion(question, new List<int>());
                        List<int> choices = ui.GetChoices(question.CorrectAnswers);
                        points += logic.AddPoints(question, choices);
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
                if (logic.InvalidCheck(choice))
                {
                    Console.WriteLine($"Invalid choice. Please choose '{Constants.PLAY}' to play, '{Constants.BUILD}' to build, or '{Constants.EXIT}' to exit.");
                }
            }
        }

    }
}

