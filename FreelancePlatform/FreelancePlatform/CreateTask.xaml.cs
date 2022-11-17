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
    /// Interaction logic for CreateTask.xaml
    /// </summary>
    public partial class CreateTask : Page
    {
        public CreateTask()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB.customers[DB.index].createdTasks.Add(new Task(TaskInfoTitle.Text, AboutTaskInfo.Text, SkillsTaskInfo.Text, DeadlineTimeInfo.Text, CreatedTimeInfo.Text, "", PriceTaskInfo.Text, DB.customers[DB.index], null, true));
            NavigationService.Navigate(new CustomerPage());
        }
    }
}
