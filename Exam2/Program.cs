using System.Diagnostics.CodeAnalysis;

namespace Exam2
{
   
    internal class Program
    {
        
       
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Examination system\nPlease Choose the the Subject of the Exam:");
        
            Subject HTML = new Subject(1 , "HTML");
            Subject CSS = new Subject(2, "CSS");
            Subject JS = new Subject(3, "JS");
            Subject Csharp = new Subject(4, "C#");
    
            Subject[] subjects = { JS, Csharp, CSS , HTML };
     
            Subject.BubbleSort(subjects);
           
            for (int i =0;i<subjects.Length ;i++) 
            {
            Console.WriteLine(subjects[i].ToString());
            }
          
            int choosedSubject = Subject.takeSubjectId(subjects.Length, subjects);
            Console.Clear();

            subjects[choosedSubject].BeginEaxm();
            Console.WriteLine("\n");
            Console.Clear();
         

          

        }
    }
}
