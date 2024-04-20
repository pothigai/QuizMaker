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
            QandA QA = new QandA();
            QuestionListLogic QLL = new QuestionListLogic();

            bool build = UI.scanInputBool("Do you want to build a quiz?");

            if (build)
            {
                int numQuestions = UI.scanInputInteger("How many questions do you want to add?");

                for (int q = 0; q < numQuestions; q++)
                {
                    QuestionList.Add(QLL.CreateQuestion());
                }
               QLL.CreateXmlFile(QuestionList,Constants.PATH);
            }

            bool play = UI.scanInputBool("Do you want to play?");
            
            if (play)
            {
                int points = 0;

                QuestionList = QLL.ReadXmlFile(Constants.PATH);

                foreach (var question in QuestionList)
                {
                    points += QLL.PresentQuestion(question);
                    Console.WriteLine("Total points:");
                    Console.WriteLine(points);
                }
            }
            else
            {
                Console.WriteLine("Exiting.");
            }

        }
    }
}

