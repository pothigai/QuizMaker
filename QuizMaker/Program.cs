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

            int numQuestions = UI.scanInputInteger("How many questions do you want to add?");

            for (int q = 0; q < numQuestions; q++)
            {
                QuestionList.Add(QandA.CreateQuestion());
            }

            XmlSerializer writer = new XmlSerializer(typeof(List<QandA>));
            var path = @"..\..\..\File.txt";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuestionList);
            }

            foreach (var question in QuestionList)
            {
                QandA.PresentQuestion(question);
            }

        }
    }
}

