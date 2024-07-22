using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ConsoleApp1
{
    public class WorkDetails : EventArgs
    {
        public int hours { get; set; }
        public WorkType workType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }

    public delegate void WorkPerformed(int hours , WorkType workType);
    public delegate void WorkCompleted();
    public delegate void Name(string name);
    public class Worker
    {
        public event WorkPerformed workPerformed;
        
        public event WorkCompleted workCompleted;
        public event Name nameChanged;

        public void DoWork(int hours , WorkType workType)
        {
            for (int i = 0; i < hours; i++) {
                OnWp(i + 1, workType);
                
                Thread.Sleep(1000);
            }
            OnCp();
        }

        protected virtual void OnWp(int hours, WorkType workType)
        {
           workPerformed.Invoke(hours, workType);  
        }
        protected virtual void OnCp()
        {
            workCompleted.Invoke();
        }
        public void namechange(string name)
        {
           onnamechange(name);
        }
        public void onnamechange(string name)
        {
            nameChanged.Invoke(name);
        }
        //public Worker()
        //{
        //    this.nameChanged += new Name(this.namechange);
        //}
    }
   class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            worker.workPerformed += Worker_WorkPerformed;
           // worker.workPerformed += Worker_LogWork;
            worker.workCompleted += Worker_WorkCompleted;
          //  worker.workPerformed += Worker_LogCompletion;

            worker.DoWork(5, WorkType.GenerateReports);
            worker.nameChanged += names;
            worker.namechange("Devarsh");

            Console.ReadLine();
        }
        private static void Worker_WorkPerformed(int hours , WorkType workType)
        {
            Console.WriteLine($"Performed {hours} hour(s) of {workType})");
        }
        //public static void Worker_LogWork(object sender, WorkDetails e)
        //{
        //    Console.WriteLine($"[Log] Work Perfoemed : {e.hours} hours of {e.workType}");
        //}
        static void names(string name)
        {
            Console.WriteLine(name);
        }
        private static void Worker_WorkCompleted()
        {
            Console.WriteLine("Work Completed");
        }
        //private static void Worker_LogCompletion(object sender, EventArgs e)
        //{
        //    // Simulate logging to a file
        //    Console.WriteLine("[Log] Work completed");
        //}
    }

    public enum WorkType
    {
        Golf,
        GoToMeetings,
        GenerateReports,
    }
}

