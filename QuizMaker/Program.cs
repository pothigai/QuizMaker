﻿using System.Reflection.Metadata.Ecma335;
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

            if (choice == Constants.PLAY)
            {
                int points = 0;

                QuestionList = QLL.ReadXmlFile(Constants.PATH);

                foreach (var question in QuestionList)
                {
                    UI.PresentQuestion(question);
                    List<int> choices = UI.GetChoices(question.CorrectAnswers);
                    points += QLL.AddPoints(question, choices);
                    Console.WriteLine("Total points:");
                    Console.WriteLine(points);
                }
            }
            if (choice == Constants.EXIT)
            {
                Console.WriteLine("Exiting.");
            }

        }
    }
}

