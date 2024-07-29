﻿using Exam2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{ 
    internal  class Final :Exam,IMCQ,ITrueFalse
    {


        public override Question[] BuildExam(int numberofQuestion)
        {

            Question[] QuestionsList = new Question[numberofQuestion];
           
               

                    for (int i = 0; i < numberofQuestion; i++)
                    {
                        Console.Write("Please Enter the Type of the Question [1 for MCQ | 2 for true&false ]: ");
                        int.TryParse(Console.ReadLine(), out int numberoftype);
                        Console.Clear();
                        do
                        {
                            if (numberoftype == 1)
                            {
                                QuestionsList[i] = IMCQ.MCQ(i + 1, numberoftype);

                            }
                            if (numberoftype == 2)
                            {
                                QuestionsList[i] = ITrueFalse.TF(i + 1, numberoftype);
                            }
                        } while (numberoftype > 2);
                        Console.Clear();

                    }
             

            Console.Clear();
            return QuestionsList;
        }
     
        public override void ShowResult(Question[] questions, Answer[] UserAnswerList, int[] Marks, Stopwatch time)
        {

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {questions[i].Header}: {questions[i].Body}\n");
                int UserchoiceNumber = UserAnswerList[i].AnswerNum;
                if (questions[i].Type == 1)
                {
                    Console.WriteLine($"Your Answer => {UserchoiceNumber}.{questions[i].AnswersText?[(UserchoiceNumber - 1)]}");
                    Console.WriteLine($"Correct Answer => {questions[i].CorrectAnswerNum}.{questions[i].CorrectAnswerText}");
                }
                else if (questions[i].Type == 2)
                {

                    Console.WriteLine($"Your Answer => {UserchoiceNumber}.{questions[i].AnswersText?[UserchoiceNumber]}");
                    Console.WriteLine($"Correct Answer => {questions[i].CorrectAnswerNum}.{questions[i].CorrectAnswerText}");
                }
                Console.WriteLine("\n-----------------\n");
            }
            Console.WriteLine($"Your Grade is: {Marks[0]} from {Marks[1]}");
            Console.WriteLine($"time taken: {time}");
            Console.WriteLine("Thank you");
        }

        public override void StartExam(int typeofExam, int numberofQuestion, Question[] questionsList)
        {
            Console.WriteLine("Do you want to start the Exam(Y|N): ");
            Stopwatch time = new Stopwatch();
            bool YN = char.TryParse(Console.ReadLine()?.ToLower(), out char yesORno);
            Console.Clear();
            if (YN && yesORno == 'y')
            {
                time.Start();
                Answer[] UserAnswersList = DisplayExam(numberofQuestion, questionsList);
                int[] resultAndTotal = CalculateMark(numberofQuestion, questionsList, UserAnswersList);
                Console.Clear();
                time.Stop();
           
                    ShowResult(questionsList, UserAnswersList, resultAndTotal,time);
               
                Console.ReadLine();

            }
            else
            {

                Console.WriteLine("Thank you");

            }

        }

        public override int[] CalculateMark(int n, Question[] QuestionsList, Answer[] UserAnswerList)
        {

            int[] CalculatedAnswer = { 0, 0 };
            for (int i = 0; i < n; i++)
            {
                if (QuestionsList[i].CorrectAnswerNum == UserAnswerList[i].AnswerNum)
                {
                    CalculatedAnswer[0] += QuestionsList[i].Mark;
                }
                CalculatedAnswer[1] += QuestionsList[i].Mark;
            }
            return CalculatedAnswer;
        }
        public override Answer[] DisplayExam(int n, Question[] QuestionsList)
        {
            Answer[] UserAnswerList = new Answer[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(QuestionsList[i].ToString());
                bool IsaNumberOfchoices;
                int answer;
                if (QuestionsList[i].Type == 1)
                {
                    do
                    {
                        Console.WriteLine(IMCQ.DisplayChoices(QuestionsList[i].AnswersText));
                        Console.Write("\nEnter your answer Number: ");
                        IsaNumberOfchoices = int.TryParse(Console.ReadLine(), out answer);
                    }
                    while (!IsaNumberOfchoices && answer <= 0 && answer > 3);
                    UserAnswerList[i] = new Answer(i + 1, answer);

                }
                else if (QuestionsList[i].Type == 2)
                {
                    do
                    {
                        Console.WriteLine(ITrueFalse.trueFalseChoices());
                        Console.Write("Enter your answer (1) if True or (0) if False: ");
                        IsaNumberOfchoices = int.TryParse(Console.ReadLine(), out answer);
                    }
                    while (!IsaNumberOfchoices && answer <= 0 && answer > 3);
                    UserAnswerList[i] = new Answer(i + 1, answer);

                }
                Console.Clear();
            }
            Console.Clear();
            return UserAnswerList;
        }

    }

}

