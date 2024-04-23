using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuestionListLogic
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QandA>));

        public List<int> GetChoices(int numberOfAnswers)
        {
            Console.WriteLine("Enter your option");

            List<int> choices = new List<int>();

            for (int i = 0; i < numberOfAnswers; i++)
            {
                choices.Add(int.Parse(Console.ReadLine()));
            }

            return choices;
        }
        public bool[] EvaluateAnswers(QandA question, List<int> choices)
        {
            bool[] results = new bool[question.CorrectAnswers];

            for (int i = 0; i < choices.Count; i++)
            {
                if (question.Answer.Contains(question.Options[choices[i] - 1]))
                {
                    results[i] = true;
                }
                else
                {
                    results[i] = false;
                }
            }

            return results;
        }
        public void CreateXmlFile(List<QandA> QuestionList, string filePath)
        {
            using (FileStream file = File.Create(filePath))
            {
                serializer.Serialize(file, QuestionList);
            }
        }
        public List<QandA> ReadXmlFile(string filePath)
        {
            var QuestionList = new List<QandA>();
            using (FileStream file = File.OpenRead(filePath))
            {
                QuestionList = serializer.Deserialize(file) as List<QandA>;
            }
            return QuestionList;
        }
    }
}
