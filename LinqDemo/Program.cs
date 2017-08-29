using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Employee
    {
        public int EmployeeID { get; set; }
    }
    class Worked
    {
        public int WorkerID { get; set; }
        public int HoursWorked { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee frank = new Employee { EmployeeID = 10 };
            Employee joe = new Employee { EmployeeID = 20 };
            Employee will = new Employee { EmployeeID = 30 };
            Employee renee = new Employee { EmployeeID = 40 };
        }
    }
}
