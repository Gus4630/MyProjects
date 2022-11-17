using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FreelancePlatform
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < DB.executors.Count; i++)
            {
                if (DB.executors[i].Login == usernameText.Text && DB.executors[i].Password == passwordText.Password)
                {
                    DB.index = i;
                    NavigationService.Navigate(new ExecutorPage());
                }
                

            }

            for (int i = 0; i < DB.customers.Count; i++)
            {
                if (DB.customers[i].Login == usernameText.Text && DB.customers[i].Password == passwordText.Password)
                {
                    DB.index = i;
                    NavigationService.Navigate(new CustomerPage());
                }


            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
