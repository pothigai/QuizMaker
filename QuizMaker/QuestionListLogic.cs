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

        public bool EvaluateAnswers(QandA question, List<int> choices)
        {
            List<string> chosenOptions = choices.Select(choice => question.Options[choice - 1].Trim().ToLower()).ToList();
            List<string> correctAnswers = question.Answer.Select(a => a.Trim().ToLower()).ToList();

            if (chosenOptions.Count != correctAnswers.Count)
            {
                return false;
            }
            foreach (var correctAnswer in correctAnswers)
            {
                if (!chosenOptions.Contains(correctAnswer))
                {
                    return false;
                }
            }

            return true;
        }


        public void CreateXmlFile(List<QandA> QuestionList)
        {
            using (FileStream file = File.Create(Constants.PATH))
            {
                serializer.Serialize(file, QuestionList);
            }
        }

        public List<QandA> ReadXmlFile()
        {
            var QuestionList = new List<QandA>();

            if (!File.Exists(Constants.PATH))
            {
                Console.WriteLine($"File '{Constants.PATH}' does not exist.");
                return QuestionList;
            }

            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                QuestionList = serializer.Deserialize(file) as List<QandA>;
            }
            return QuestionList;
        }

        public int AddPoints(QandA question, List<int> choices)
        {
            bool result = EvaluateAnswers(question, choices);
            int score;

            if (result)
            {
                score = 1;
            }
            else
            {
                score = 0;
            }

            return score;
        }

        public bool InvalidCheck(char choice)
        {
            return !(choice == Constants.BUILD || choice == Constants.PLAY || choice == Constants.EXIT);
        }
    }
}
