using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Interfaces
{
    internal interface IMCQ
    {

        public static string[] takeChoices()
        {
            string[] ArryOfchoices = new string[3];
            Console.WriteLine($"Enter the choices: ");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1}. ");
                string? A = Console.ReadLine();


                if (A is null || A == "")
                {
                    Console.WriteLine("the input is not Valid");
                    i--;
                }
                else
                {

                    ArryOfchoices[i] = new string(A);

                }


            }



            return ArryOfchoices;
        }
        public static string DisplayChoices(string[]? choices) 
        {
            string Choices = $"1.{choices?[0]}\n2.{choices?[1]}\n3.{choices?[2]}";
            return Choices;
        }
        public static Question MCQ(int id, int type)
        {
            Question MCQ;
            Question QuestionInfo = Question.takeQuestions(id);
            string? Questions = QuestionInfo.Body;
            int Mark = QuestionInfo.Mark;
            string[] Choices = takeChoices();
            int CorrectAnswerNumber = Answer.CorrectAnswar(id, type, Choices).AnswerNum;

            string? CorrectAnswerText = Choices[CorrectAnswerNumber-1];
          

            MCQ = new Question(1,id, Questions, Choices, CorrectAnswerNumber, CorrectAnswerText, Mark);


            return MCQ;
        }
    }
}
