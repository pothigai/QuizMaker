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

            bool build = UI.scanInputBool("Do you want to build a quiz?");

            if (build)
            {
                int numQuestions = UI.scanInputInteger("How many questions do you want to add?");

                for (int q = 0; q < numQuestions; q++)
                {
                    QuestionList.Add(QandA.CreateQuestion());
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<QandA>));
                var path = @"..\..\..\File.txt";
                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, QuestionList);
                }
            }
            bool play = UI.scanInputBool("Do you want to play?");
            if (play)
            {
                int points = 0;
                XmlSerializer serializer = new XmlSerializer(typeof(List<QandA>));
                var path = @"..\..\..\File.txt";
                using (FileStream file = File.OpenRead(path))
                {
                    QuestionList = serializer.Deserialize(file) as List<QandA>;
                }

                foreach (var question in QuestionList)
                {
                    points += QA.PresentQuestion(question);
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

