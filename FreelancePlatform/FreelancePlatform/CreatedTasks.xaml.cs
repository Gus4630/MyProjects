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
    /// Interaction logic for CreatedTasks.xaml
    /// </summary>
    public partial class CreatedTasks : Page
    {
        public CreatedTasks()
        {
            this.DataContext = DB.customers[DB.index];
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CustomerPage());
        }
    }
}
