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
        public string WorkedIn { get; set; }
        public string Name { get; set; }
    }
    class Result
    {
        public int EmployeeID { get; set; }
        public IEnumerable<Worked> Collection { get; set; }
        public Result(int employeeID, IEnumerable<Worked> collection)
        {
            this.EmployeeID = employeeID;
            this.Collection = collection;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
                 
            Employee frank = new Employee { EmployeeID = 10 };
            Employee joe = new Employee { EmployeeID = 20 };
            Employee will = new Employee { EmployeeID = 30 };
            Employee renee = new Employee { EmployeeID = 40 };
            var employees = new Employee[] { frank, joe, will, renee };

            Worked shoes = new Worked { WorkerID = 10, HoursWorked = 10, WorkedIn = "Shoes", Name = "Frank", };
            Worked hardware = new Worked { WorkerID = 20, HoursWorked = 8, WorkedIn = "Hardware", Name = "Joe" };
            Worked custServ = new Worked { WorkerID = 20, HoursWorked = 2, WorkedIn = "Customer Service", Name = "Joe"};
            Worked cashier = new Worked { WorkerID = 30, HoursWorked = 6, WorkedIn = "Cashier", Name = "William" };
            Worked management = new Worked { WorkerID = 40, HoursWorked = 10, WorkedIn = "Management", Name = "Renee" };
            var worked = new Worked[] { shoes, hardware, custServ, cashier, management };

            var query = employees.GroupJoin(worked, //argument 1 is the secondary collection
                                            e => e.EmployeeID, //function that returns the key from the first object type. EmployeeID in the employees list
                                            w => w.WorkerID, //function that returns the key from the second object type. WorkerID in the worked collection
                                            (e, result) => new Result(e.EmployeeID, result)); // (e, result) is parameter, after => is function that stores the now grouped object with the group itself ????
            foreach (var result in query)
            {
                Console.WriteLine($"\nID: {result.EmployeeID}");
                foreach (var item in result.Collection) //loop over the collection named result
                {
                    Console.WriteLine($"{item.Name} worked {item.HoursWorked} in {item.WorkedIn}");
                }
            }
            Console.ReadLine();                                
        }
    }
}
//Regular classes used in this examle. It is probably more common to use anonymous types with GroupJoin.  var person = new { name = "Mike", age = 32 };
