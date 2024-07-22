using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    public class StudentDatabase
    {
        GenericRepository<Student> studentrepository = new GenericRepository<Student>();

        public void Add(Student student)
        {
            studentrepository.Add(student);
        }
        public void Remove(string name)
        {
            Student student_name = studentrepository.values.Find(r => r.Student_Name.ToLower() == name.ToLower());
            if(student_name != null)
            {
                studentrepository.Remove(student_name);
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found");
            }
        }

        public void Update(int id , string name , string email , long phone , string city)
        {
            Student s_id = studentrepository.values.Find(st => st.Student_Id == id);
            if(s_id != null)
            {
                s_id.Student_Id = id;
                s_id.Student_Name = name;
                s_id.Student_Email = email;
                s_id.Student_Phone = phone;
                s_id.Student_City = city;
                studentrepository.Update(s_id);
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found");
            }
        }

        public void Search(String name)
        {
            Student s_name = studentrepository.values.Find(stu => stu.Student_Name.ToLower() == name.ToLower());
            if( s_name != null )
            {
                studentrepository.Search(s_name);
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found");
            }
        }

        public void GetAllStudents()
        {
            var student = studentrepository.GetStudent();
            foreach (var item in student)
            {
                //Console.WriteLine($"No : {student.Count + 1}");
                Console.WriteLine($"Name : {item.Student_Name}");
                Console.WriteLine($"City : {item.Student_City}");
                Console.WriteLine($"Phone : {item.Student_Phone}");
            }

        }
    }
}
