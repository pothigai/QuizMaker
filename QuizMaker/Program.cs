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

            bool isValidChoice = false;

            while (!isValidChoice)
            {
                char choice = ui.ScanInputChar($"Do you want to play ({Constants.PLAY}) or build ({Constants.BUILD}) or exit ({Constants.EXIT})?");

                if (logic.isValidMode(choice))
                {
                    ui.PrintOutputMessage($"Invalid choice. Please choose '{Constants.PLAY}' to play, '{Constants.BUILD}' to build, or '{Constants.EXIT}' to exit.");
                }
                if (choice == Constants.BUILD)
                {
                    ui.AddQuestion(QuestionList);
                    logic.CreateXmlFile(QuestionList);
                    isValidChoice = true;
                }
                if (choice == Constants.PLAY)
                {
                    int points = 0;
                    QuestionList = logic.ReadXmlFile();

                    if (QuestionList == null)
                    {
                        Console.WriteLine($"File '{Constants.PATH}' does not exist.");
                    }
                    else
                    {
                        foreach (var question in QuestionList)
                        {
                            ui.PresentQuestion(question, new List<int>());
                            List<int> choices = ui.GetChoices();
                            int score = logic.AddPoints(question, choices);
                            ui.PrintResult(score);
                            points += score;
                            ui.PrintOutputMessage("Total points:");
                            ui.PrintOutputMessage(points.ToString());
                        }
                    }
                    isValidChoice = true;
                }
                if (choice == Constants.EXIT)
                {
                    ui.PrintOutputMessage("Exiting.");
                    isValidChoice = true;
                }
            }
        }

    }
}

