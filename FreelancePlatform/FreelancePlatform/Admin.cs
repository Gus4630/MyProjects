using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform
{
    public class Admin : User, IAccountSetup
    {

        public Admin()
        {

        }

        void ban_user() { }
        void delete_task() { }

        public void changePersonalInfo()
        {
            throw new NotImplementedException();
        }
    }
}
