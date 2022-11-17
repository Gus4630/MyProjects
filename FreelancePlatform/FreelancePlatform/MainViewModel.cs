using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FreelancePlatform
{
    public class MainViewModel : ViewModelBase
    {


        private Page Login;
        private Page Registration;
        private Page Tasks;
        private Page SearchOrdersPage;
        private Page CurrentOrdersPage;
        private Page executorPage;
        private Page _currentPage;
        public Page CurrentPage { get => _currentPage; set => _currentPage = value; }


        public MainViewModel()
        {
            Login = new Login();
            Registration = new Registration();
            Tasks = new Pages.Tasks();
            SearchOrdersPage = new Pages.SearchOrdersPage();
            CurrentOrdersPage = new Pages.CurrentOrdersPage();
            executorPage = new ExecutorPage();
            CurrentPage = Login;
        }
        

        public ICommand executorPageSwitch
        {

            get
            {
                return new RelayCommand(() => CurrentPage = executorPage);
            }
        }
    }

}
