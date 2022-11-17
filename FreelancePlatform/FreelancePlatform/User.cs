using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform
{
    public abstract class User : INotifyPropertyChanged
    {

        string _login;
        string _password;
        string _name;
        string _email;
        string _dateOfBirth;
        string _number;
        bool _isVerified;
        bool _isEnabled;
        double budget;

        public string Login { get => _login; set { _login = value; OnPropertyChanged("Login"); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged("Password"); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged("Name"); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged("Email"); } }
        public string DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged("DateOfBirth"); } }
        public string Number { get => _number; set { _number = value; OnPropertyChanged("Number"); } }
        public bool IsVerified { get => _isVerified; set { _isVerified = value; OnPropertyChanged("IsVerified"); } }
        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; OnPropertyChanged("IsEnabled"); } }
        public double Budget { get => budget; set { budget = value; OnPropertyChanged("Budget"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
