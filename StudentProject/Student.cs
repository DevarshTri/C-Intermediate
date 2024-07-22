using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    public class Student
    {
        public int Student_Id { get; set; }
        public string Student_Name { get;set; }
        public string Student_Email { get; set; }
        public long Student_Phone { get; set; }
        public string Student_City { get; set; }

        public Student(int student_Id, string student_Name, string student_Email, long student_Phone, string student_City)
        {
            Student_Id = student_Id;
            Student_Name = student_Name;
            Student_Email = student_Email;
            Student_Phone = student_Phone;
            Student_City = student_City;
        }
    }
}
