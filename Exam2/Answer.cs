using Exam2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Answer
    {
    public int AnswerId { get; set;}
    public int AnswerNum {  get; set; }
    public string[]? AnswersText { get; set; }
    public string? CorrectAnswerText { get; set; }


        public override string ToString()
        {
            return $"{AnswerNum}.{CorrectAnswerText}";
        }
        public Answer(int id , int correctAnswer ) 
    {
        AnswerId = id ;
        AnswerNum = correctAnswer;
        
 
    }

        public Answer(int id, string[] answerChoices)
        {
            AnswerId = id;

            AnswersText = answerChoices;
        }

        public static Answer CorrectAnswar(int n, int type, string[]? choices)
        {
            bool IsaNumberOfchoices;
            int correct;
            string? answerText = "";
            do
            {
                if(type==1)
                Console.Write($"Enter the number of the correct choice: ");

                else
                Console.Write($"Enter number (1) if True or number (0) if False: ");

                IsaNumberOfchoices = int.TryParse(Console.ReadLine(), out  correct);
                if (type==1) {
                    if (!IsaNumberOfchoices && correct <= 0 && correct > 3)
                    {
                        Console.WriteLine("the input is not Valid");

                    }
                    else {
                        answerText = choices?[correct - 1];
                    }
                } else if (type==2) 
                {
                    if (!IsaNumberOfchoices && (correct == 0! || correct == 1!))
                    {
                        Console.WriteLine("the input is not Valid");

                    }
                    else {
                        answerText = choices?[correct];
                    }
                }
            }
            while (!IsaNumberOfchoices);
            Answer answer = new Answer(n, correct);
            return answer;
        }
    }

}
