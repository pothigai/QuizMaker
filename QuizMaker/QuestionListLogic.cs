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
        public int AddPoints(QandA question, List<int> choices)
        {
            int score = 0;

            bool[] results = EvaluateAnswers(question, choices);

            Console.WriteLine("Result:");
            if (results.Contains(false))
            {
                Console.WriteLine("Wrong.");
                score = 0;
            }
            else
            {
                Console.WriteLine("Correct!");
                score = 1;
            }
            return score;
        }
    }
}
