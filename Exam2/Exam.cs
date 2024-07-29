using Exam2.Interfaces;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal abstract class Exam
    {
        /*   6. Design a Base class Exam describe the common attributes concerning the exam:
                   a.Time of exam
                   b.Number of Questions
                   c.Show Exam Functionality that its implementations will be
                     different for each exam based on its type.                          */
        public Stopwatch? Time {  get; set; }
        public int NumberOfQuestions {  get; set; }


        public abstract Question[] BuildExam(int numberofQuestion);
        //{

        //    Question[] QuestionsList = new Question[numberofQuestion]; 
        //    do
        //    {
        //        if (typeofexam == 1)
        //        {
        //            QuestionsList = Final.BuildFinalExam(numberofQuestion);
        //        }
        //        else if (typeofexam == 2)
        //        {

        //            QuestionsList = Practical.BuildPracticalExam(numberofQuestion);
        //        }
        //        else
        //        {
        //            Console.WriteLine("invalid choice!");
        //        }
        //    } while (typeofexam<=0 && typeofexam>2);

            
        //          Console.Clear();
        //    return QuestionsList;
        //    }
        public abstract void StartExam(int typeofExam, int numberofQuestion, Question[] questionsList);

        public abstract Answer[] DisplayExam(int n, Question[] QuestionsList);
   
        public abstract int[] CalculateMark(int n, Question[] QuestionsList, Answer[] UserAnswerList);
     

        public abstract  void ShowResult(Question[] questions, Answer[] UserAnswerList, int[] Marks,Stopwatch time);
    }


}



