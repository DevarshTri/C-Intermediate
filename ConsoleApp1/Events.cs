using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void adfd(string name);
    internal class Events
    {
        public event adfd adfds;

        public Events()
        {
            this.adfds += new adfd(this.names);
        }
        public void names(string name)
        {
            Console.WriteLine(name);
        }
    }
}
