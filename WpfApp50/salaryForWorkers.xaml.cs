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
    /// Interaction logic for salaryForWorkers.xaml
    /// </summary>
    public partial class salaryForWorkers : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public salaryForWorkers(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            for (int i = 1; i < 13; i++)
            {
                month_lsb.Items.Add(i);
            }
        }

        private void clclte_btn_Click(object sender, RoutedEventArgs e)
        {
            slry_lbl.Content = "Salary:";
            double slry =0;
            if (emp != null && month_lsb.SelectedIndex != -1 && year_txb.Text!="")
            {
                List<shift> lst_s = db1.shift.ToList();
                foreach (shift s in lst_s)
                {
                    if (emp == s.employee && month_lsb.SelectedIndex + 1 == s.date.Month)
                        slry += Convert.ToDouble(emp.employee_type.salary_per_hour) * Convert.ToDouble(s.time_of_working);
                }
                slry_lbl.Content += " " + slry + "₪";
            }
            else
            {
                MessageBox.Show("fill all the fields","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void year_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(year_txb.Text, out long a))
                year_txb.Clear();
        }
    }
}
