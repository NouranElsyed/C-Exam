using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Question
    {
        public int Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }
        public int Type { get; set; }
        public string[]? AnswersText { get; set; }
        public int CorrectAnswerNum { get; set; }
        public string? CorrectAnswerText { get; set; }


        public Question(int type ,int id, string? question, string[]? choices, int answer,string? answerText ,int mark)
        {
            Type = type;
            Header = id;
            Body = question;
            AnswersText = choices;  
            CorrectAnswerNum = answer;
            CorrectAnswerText = answerText;
            Mark = mark;

        }


        public Question(int header, string? body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        public override string ToString()
        {

            return $"Question {Header}: {Body}\n\n";
        }
        public static Question takeQuestions(int n)
        {
            Question question;
            string? q;
                do {
                    Console.Write($"Enter the Question number {n}: ");
                    q = Console.ReadLine();
                if (q is null || q == "")
                {
                    Console.WriteLine("the input is not Valid");
                }
            } while (q is null || q == "");
            bool markIsNumber;
                int mark;
                do
                {
                    Console.Write($"Enter the mark of the Question {n}: ");
                    markIsNumber = int.TryParse(Console.ReadLine(), out  mark);
                    if (!markIsNumber && mark == 0) { Console.WriteLine("the input of the mark number is not valid Please try again!"); }

                } while (!markIsNumber && mark == 0);

                  question = new Question(n + 1, q, mark);

            return question;
        }

    }
}
