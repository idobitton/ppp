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
    /// Interaction logic for entrySystem.xaml
    /// </summary>
    public partial class entrySystem : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public entrySystem( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void entry_btn_Click(object sender, RoutedEventArgs e)
        {
            if (emp != null)
            {
                if (MessageBox.Show("Do you want to put in " + emp.first_name + " " + emp.last_name + " to the system?", "Enter?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    emp.is_working_now = "at shift";
                    shift shift = findShift(emp);
                    string entry_time = DateTime.Now.ToString().Substring(DateTime.Now.ToString().IndexOf(" ") + 1);
                    shift.shift_time.entry_time = entry_time;
                    db1.SaveChanges();
                }
            }
            else
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            update();
        }

        private shift findShift(employee emp)
        {
            List<shift> lst_s = new List<shift>();
            lst_s = db1.shift.ToList();
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
            List<employee> lst_e = new List<employee>();
            List<employee> employees = new List<employee>();
            lst_e = db1.employee.ToList();
            string today_date = DateTime.Now.ToString("dd/MM/yyyy");
            foreach (employee emp in lst_e)
            {
                shift sh = findShift(emp);
                if (sh != null)
                {
                    string shift_date = sh.date.ToString("dd/MM/yyyy");
                    if (emp.is_working_now == "not at shift" && emp.deleted == "exist" && today_date == shift_date)
                    {
                        employees.Add(emp);
                    }
                }
            }
            emp_dtgrid.ItemsSource = employees;
        }
    }
}
