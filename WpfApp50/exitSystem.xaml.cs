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
            if (emp != null)
            {
                if (MessageBox.Show("Do you want to take out " + emp.first_name + " " + emp.last_name + " from the system?", "EXIT?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    emp.is_working_now = "not at shift";
                    shift shift = findShift(emp);
                    string checkout_time = DateTime.Now.ToString().Substring(DateTime.Now.ToString().IndexOf(" ") + 1);
                    shift.shift_time.checkout_time = checkout_time;
                    double total_minutes;
                    double time_of_working=0;
                    double entry_hour = Convert.ToInt32(shift.shift_time.entry_time.ToString().Substring(0,2)); 
                    double entry_minute = Convert.ToInt32(shift.shift_time.entry_time.ToString().Substring(3,2)); 
                    double exit_hour = Convert.ToInt32(shift.shift_time.checkout_time.ToString().Substring(0,2)); 
                    double exit_minute = Convert.ToInt32(shift.shift_time.checkout_time.ToString().Substring(3,2)); 
                        time_of_working += exit_hour - entry_hour;
                        if (exit_minute- entry_minute > 0)
                        {
                            total_minutes = exit_minute - entry_minute;
                            time_of_working += total_minutes/ 60;
                        }
                        else
                        {
                            time_of_working -= 1;
                        total_minutes = exit_minute - entry_minute + 60;
                            time_of_working += total_minutes/ 60;
                        }
                    shift.time_of_working += Convert.ToDecimal(time_of_working);
                    db1.SaveChanges();
                }
            }
            else
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            update();
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
            update();      
        }

        private void update()
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            List<employee> lst_e = db1.employee.ToList();
            List<employee> employees = new List<employee>();
            foreach (employee emp in lst_e)
            {
                if (emp.is_working_now == "at shift" && emp.deleted == "exist")
                {
                    employees.Add(emp);
                }
            }
            emp_dtgrid.ItemsSource = employees;
        }

        private shift findShift(employee emp)
        {
            List<shift> lst_s = db1.shift.ToList();
            string today_date = DateTime.Now.ToString("dd/MM/yyyy");
            foreach (shift sh in lst_s)
            {
                string shift_date = sh.date.ToString("dd/MM/yyyy");
                if (today_date == shift_date && sh.employee == emp)
                {
                    return sh;
                }
            }
            return null;
        }
    }
}
