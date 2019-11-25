using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public delegate bool StudentPredicateDelegate(Student student);
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public static bool IsAge(Student student)
        {
            return student.Age >= 18;
        }

        public static bool IsFirstName(Student student)
        {
            return student.FirstName[0] == 'A';
        }

        public static bool IsLastName(Student student)
        {
            return student.LastName.Length > 3;
        }
    }
}
