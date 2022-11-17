using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform
{
    public class Executor : User, IAccountSetup
    {
        int _finished_orders;
        string skills;
        string _about;
        IList<string> _billing;
        IList<Task> _accepted_tasks = new List<Task>();

        public Executor(string login, string password, string name, string email, string dateofbirth, string number, bool is_verified, bool is_enabled, double budget)
        {
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.IsEnabled = is_enabled;
            this.Budget = budget;
            this.IsVerified = is_verified;
            this.DateOfBirth = dateofbirth;
            this.Number = number;
            Finished_orders = 0;
            Skills = "";
            About = "";            

        
      }
        public Executor()
        {

        }

        public int Finished_orders { get => _finished_orders; set => _finished_orders = value; }
        public string Skills { get => skills; set => skills = value; }
        public string About { get => _about; set => _about = value; }
        public IList<string> Billing { get => _billing; set => _billing = value; }
        public IList<Task> Accepted_tasks { get => _accepted_tasks; set => _accepted_tasks = value; }

        public void changePersonalInfo()
        {
            throw new NotImplementedException();
        }

        void leave_the_task() { }
        void request_toAccept() { }


    }
}
