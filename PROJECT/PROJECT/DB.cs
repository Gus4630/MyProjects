using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    internal class DB
    {
        public List<Dictionary> dictionaries = new List<Dictionary>();
        public List<Admin> admins = new List<Admin>();
        public List<User> users = new List<User>();

    }
}
