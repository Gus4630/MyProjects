using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    
    public partial class Registration : Page
    {
        
        public Registration()
        {
            
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (UserTypeComboBox.SelectedIndex == 0)
            {       
                
                //Executor ex = new Executor();
                DB.executors.Add(new Executor(usernameText.Text, passwordtext.Password, nameText.Text, emailText.Text, birthDate.Text, phoneNumberText.Text, true, true, 0));
                DB.index = DB.executors.Count - 1;
                NavigationService.Navigate(new ExecutorPage());
                
            }
            else
            {
                DB.customers.Add(new Customer(usernameText.Text, passwordtext.Password, nameText.Text, emailText.Text, birthDate.Text, phoneNumberText.Text, true, true, 0));

                DB.index = DB.customers.Count - 1;
                NavigationService.Navigate(new CustomerPage());
                
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
