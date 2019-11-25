using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main()
        {

            List<Student> students = new List<Student>()
            { 
                new Student() { Age = 18, FirstName = "Artem", LastName = "Matviichuk" },
                new Student() { Age = 19, FirstName = "Vitaliy", LastName = "Rudenko" },
                new Student() { Age = 20, FirstName = "Oleksiy", LastName = "Luppa" },
                new Student() { Age = 44, FirstName = "Ivan", LastName = "Sobko" },
                new Student() { Age = 17, FirstName = "Yaroslav", LastName = "Pozniak" },
                new Student() { Age = 16, FirstName = "Vadim", LastName = "Derkach" },
                new Student() { Age = 21, FirstName = "Oleksandr", LastName = "Savchuk" },
                new Student() { Age = 18, FirstName = "Artur", LastName = "Savchuk" },
                new Student() { Age = 19, FirstName = "Vladislav", LastName = "Dryga" },
                new Student() { Age = 13, FirstName = "Mykyta", LastName = "Nazarenko" }
            };


            StudentPredicateDelegate myDelegate = Student.IsFirstName;
            myDelegate += Student.IsLastName;
            myDelegate += Student.IsAge;

            List<Student> result8 = students.FindStudent(myDelegate);
            Console.WriteLine("Result8:");
            result8.ShowOnScreen();


            List<Student> result9 = students.FindStudent(
                new StudentPredicateDelegate(
                    student => student.Age >= 18 && student.FirstName[0] == 'A' && student.LastName.Length > 3
                    ));
            Console.WriteLine("Result9:");
            result9.ShowOnScreen();


            List<Student> result10 = students.FindStudent(
                new StudentPredicateDelegate(
                    student => student.Age >= 20 && 25 >= student.Age
                    ));
            Console.WriteLine("Result10:");
            result10.ShowOnScreen();


            List<Student> result11 = students.FindStudent(
                new StudentPredicateDelegate(
                    student => student.FirstName == "Andrew"
                    ));
            Console.WriteLine("Result11:");
            result11.ShowOnScreen();

            List<Student> result12 = students.FindStudent(
                new StudentPredicateDelegate(
                    student => student.LastName == "Troelsen"
                    ));
            Console.WriteLine("Result11:");
            result12.ShowOnScreen();

            Console.ReadKey();
        }
    }
}
