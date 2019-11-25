using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public static class Extension
    {
        public static List<Student> FindStudent(this List<Student> students, StudentPredicateDelegate @delegate)
        {
            List<Student> result = new List<Student>();
            
            foreach (Student st in students)
            {
                if (@delegate.Invoke(st))
                {
                    result.Add(st);
                }
            }

            return result;
        }

        //Зручне розширення, якого немає в завданні
        public static void ShowOnScreen(this List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine("First name: " + student.FirstName);
                Console.WriteLine("Last name: " + student.LastName);
                Console.WriteLine("Age: " + student.Age + "\n");
            }
        }
    }
}
