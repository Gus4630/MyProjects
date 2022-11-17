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

namespace FreelancePlatform.Pages
{
    /// <summary>
    /// Interaction logic for SearchOrdersPage.xaml
    /// </summary>
    public partial class SearchOrdersPage : Page
    {
        public SearchOrdersPage()
        {
            //DataContext = DB.customers;

            InitializeComponent();
            orders.ItemsSource = DB.customers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExecutorPage());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int index2 = orders.SelectedIndex;

            DB.executors[DB.index].Accepted_tasks.Add((Task)orders.SelectedItem);

            
        }
        private void double_click(object sender, RoutedEventArgs e)
        {

            DB.double_click = orders.SelectedIndex;

            NavigationService.Navigate(new CustomerTasks());
            //DB.executors[DB.index].Accepted_tasks.Add((Task)orders.SelectedItem);


        }
    }
}
