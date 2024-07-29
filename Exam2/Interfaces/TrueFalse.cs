using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Interfaces
{
    internal interface ITrueFalse
    {
        public static string trueFalseChoices()
        {
            return "1.True\n2.False";
        }
    

        public static Question TF(int id, int type)
        {
            Question TF;
            Question QuestionInfo = Question.takeQuestions(id);

            string? Questions = QuestionInfo.Body;
            int Mark = QuestionInfo.Mark;
        
            string[]? Choices = { "False", "True" };

            int Answers = Answer.CorrectAnswar(id, type,Choices).AnswerNum ;
            //CorrectAnswerText = choices?[answer-1];
            string? CorrectAnswerText = Choices[Answers];

            TF = new Question(2,id, Questions, Choices, Answers,CorrectAnswerText,Mark);


            return TF;
        }
    }
}
