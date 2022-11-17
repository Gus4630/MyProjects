using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FreelancePlatform
{
    public class Task : INotifyPropertyChanged
    {
        string _title;
        string _about;
        string _skills;
        string _deadline;
        string _createdTime;
        string _finishedTime;
        string _price;
        Customer _taskOwner;
        Executor _executor;
        bool isActive;

        public Task(string title, string about, string skills, string deadline, string createdTime, string finishedTime, string price, Customer taskOwner, Executor executor, bool isActive)
        {
            Title = title;
            About = about;
            Skills = skills;
            Deadline = deadline;
            CreatedTime = createdTime;
            FinishedTime = finishedTime;
            Price = price;
            TaskOwner = taskOwner;
            Executor = executor;
            Is_active = isActive;            
        }

        public string Title { get => _title; set { _title = value; OnPropertyChanged("Title"); } }
        public string About { get => _about; set { _about = value; OnPropertyChanged("About"); } }
        public string Skills { get => _skills; set { _skills = value; OnPropertyChanged("Skills"); } }
        public string Deadline { get => _deadline; set { _deadline = value; OnPropertyChanged("Deadline"); } }
        public string CreatedTime { get => _createdTime; set { _createdTime = value; OnPropertyChanged("CreatedTime"); } }
        public string FinishedTime { get => _finishedTime; set { _finishedTime = value; OnPropertyChanged("FinishedTime"); } }
        public string Price { get => _price; set { _price = value; OnPropertyChanged("Price"); } }
        public Customer TaskOwner { get => _taskOwner; set { _taskOwner = value; OnPropertyChanged("TaskOwner"); } }
        public Executor Executor { get => _executor; set { _executor = value; OnPropertyChanged("Executor"); } }
        public bool Is_active { get => isActive; set { isActive = value; OnPropertyChanged("Is_active"); } }

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
