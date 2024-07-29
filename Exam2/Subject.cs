using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Subject:IComparable<Subject>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Subject(int id , string? name)  
        {
        Id = id;
        Name = name;
        }

        public override string ToString()
        {


            return $"{Id}. {Name}";
            
        }
        
        public static int takeSubjectId(int n, Subject[] array)
        {
            int choosedSubject;
            do
            {
                Console.Write($"Enter from 1 to {array.Length} to choose the subject: ");
                int.TryParse(Console.ReadLine(), out choosedSubject);
                if (!(choosedSubject >= 1 && choosedSubject <= n)) { Console.WriteLine("the input is invalid!"); }
            }
            while (!(choosedSubject >= 1 && choosedSubject <= n));
            return choosedSubject;
        }
        public static void BubbleSort(Subject[] array)
        {
            if (array is not null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int k = 0; k < array.Length - i - 1; k++)
                    {
                        if (array[k].CompareTo(array[k + 1]) == 1)
                        {
                            Swap(ref array[k], ref array[k + 1]);
                        }
                    }
                }
            }
        }
       
        public static void Swap(ref Subject X, ref Subject Y)
        {
         
            Subject temp = X;
            X = Y;
            Y = temp;
      

        }

        public int CompareTo(Subject? other)
        {
            if (other is null)
                return 1;
            else
                return this.Id.CompareTo(other.Id);
        }

        public void BeginEaxm() 
        {

            int choosedExamTypeNumber;
            do {
                Console.Write("Please Enter the type of the Exam [ 1 for Final , 2 for Practical ]: ");
                int.TryParse(Console.ReadLine(), out  choosedExamTypeNumber);
                if (!(choosedExamTypeNumber == 1 || choosedExamTypeNumber == 2)) { Console.WriteLine("the input is invalid!"); }
            } while(!(choosedExamTypeNumber == 1 || choosedExamTypeNumber == 2));
            Console.WriteLine("\n");


            int choosedExamTime;
            do
            {
                Console.Write("Please Enter the Time of the Exam from ( 30 min  to 180 min ): ");
                int.TryParse(Console.ReadLine(), out choosedExamTime);
                if (!(choosedExamTime >= 30 && choosedExamTime <= 180)) { Console.WriteLine("the input is invalid!"); }
            } while (!(choosedExamTime >= 30 && choosedExamTime <= 180));
            Console.WriteLine("\n");


            Console.Write("Please Enter the Number of Questions of the Exam: ");
            int choosedExamNumOfQuestions;
            if (choosedExamTypeNumber == 1)
            {
                Final exam = new Final();
                choosedExamNumOfQuestions = exam.NumberOfQuestions;
                int.TryParse(Console.ReadLine(), out choosedExamNumOfQuestions);
                Console.Clear();
                Question[] questionsList = exam.BuildExam(choosedExamNumOfQuestions);
                Console.Clear();
                for (int i = 0; i < questionsList.Length; i++) { Console.WriteLine(questionsList[i].ToString()); }
                Console.Clear();
                exam.StartExam(choosedExamTypeNumber, choosedExamNumOfQuestions, questionsList);
            } else if (choosedExamTypeNumber==2) 
            {
                Practical exam = new Practical();
                choosedExamNumOfQuestions = exam.NumberOfQuestions;
                int.TryParse(Console.ReadLine(), out choosedExamNumOfQuestions);
                Console.Clear();
                Question[] questionsList = exam.BuildExam(choosedExamNumOfQuestions);
                Console.Clear();
                for (int i = 0; i < questionsList.Length; i++) { Console.WriteLine(questionsList[i].ToString()); }
                Console.Clear();
                exam.StartExam(choosedExamTypeNumber, choosedExamNumOfQuestions, questionsList);
            }
        

            Console.Read();
        }

    }
}
