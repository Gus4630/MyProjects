using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace FreelancePlatform
{
    public class Customer : User, IAccountSetup
    {

        public Customer( string login, string password, string name, string email, string dateofbirth, string number, bool is_verified, bool is_enabled, double budget)
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
        }

        public IList<Task> _createdTasks = new List<Task>();
        public IList<Task> createdTasks
        {
            get { return _createdTasks; }
            set
            {
                _createdTasks = value;                
            }
        }               

        public void changePersonalInfo()
        {
            throw new NotImplementedException();
        }

     
    }
}
