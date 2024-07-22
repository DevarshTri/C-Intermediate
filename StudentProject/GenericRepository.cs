using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    public delegate void StudentHandler();
    public class GenericRepository<T> where T : Student
    {
        public event StudentHandler StudentAdded;
        public event StudentHandler StudentRemoved;
        public event StudentHandler StudentUpdated;

        public List<T> values = new List<T>();

        public GenericRepository()
        {
            this.StudentAdded += new StudentHandler(OnStudentAdd);
            this.StudentRemoved += new StudentHandler(OnStudentRemove);
            this.StudentUpdated += new StudentHandler(OnStudentUpdate);
        }

        public void Add(T value)
        {
            values.Add(value);
            StudentAdded?.Invoke();
        }

        public void Remove(T value)
        {
            if(values.Contains(value))
            {
                values.Remove(value);
                StudentRemoved?.Invoke();
            }
            else
            {
                throw new StudentNotFoundException("Student Not Found");
            }
           
        }

        public void Update(T value)
        {
            var s_index = values.FindIndex(s => s.Student_Id == value.Student_Id);
            if(s_index != -1)
            {
                values[s_index] = value;
                StudentUpdated?.Invoke();
            }
           
        }

        public void Search(T item)
        {
            var s_name = values.Find(a => a.Student_Name == item.Student_Name);
            if(s_name != null)
            {
                Console.WriteLine("Student Found");
                Console.WriteLine($"Name : {s_name.Student_Name}");
            }
        }
        public List<T> GetStudent()
        {
             return values;
        }

        public void OnStudentAdd()
        {
            Console.WriteLine("Student Added");
        }
        public void OnStudentRemove()
        {
            Console.WriteLine("Student Remove");
        }

        public void OnStudentUpdate()
        {
            Console.WriteLine("Student Update");
        }
    }
}
