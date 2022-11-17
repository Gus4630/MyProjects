using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform
{

    public class DB
    {

        public static IList<Customer> Customers { get { return customers; } set { value = customers; } }
        public static IList<Executor> Executors { get { return executors; } set { value = executors; } }

        public static IList<Customer> customers = new List<Customer>();
        public static IList<Executor> executors = new List<Executor>();
        public static IList<Admin> admins = new List<Admin> ();
        public static int index;
        public static int double_click;

    }
}
