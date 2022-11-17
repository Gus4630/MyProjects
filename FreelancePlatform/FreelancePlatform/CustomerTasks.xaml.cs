using FreelancePlatform.Pages;
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
    /// Interaction logic for CustomerTasks.xaml
    /// </summary>
    public partial class CustomerTasks : Page
    {
        public CustomerTasks()
        {
            InitializeComponent();
            currentOrders.ItemsSource = DB.customers[DB.double_click].createdTasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchOrdersPage());
        }

        private void btnAccept(object sender, RoutedEventArgs e)
        {
            DB.executors[DB.index].Accepted_tasks.Add((Task)currentOrders.SelectedItem);
        }
    }

}
