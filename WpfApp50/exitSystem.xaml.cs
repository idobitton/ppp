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
using System.Windows.Shapes;

namespace WpfApp50
{
    /// <summary>
    /// Interaction logic for exitSystem.xaml
    /// </summary>
    public partial class exitSystem : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public exitSystem( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to take out "+ emp.first_name + " " + emp.last_name + " from the system?", "EXIT?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                emp.is_working_now = "not at shift";
                db1.SaveChanges();
                this.Close();
            }
        }

        private void emp_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                emp = (employee)emp_dtgrid.SelectedItem;
            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            List<employee> lst_e = new List<employee>();
            List<employee> employees = new List<employee>();
            lst_e = db1.employee.ToList();
            foreach (employee emp in lst_e)
            {
                if (emp.is_working_now == "at shift" && emp.deleted == "exist")
                {
                    employees.Add(emp);
                }
            }
            emp_dtgrid.ItemsSource = employees;
        }
    }
}
