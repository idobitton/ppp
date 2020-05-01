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
    /// Interaction logic for addShift.xaml
    /// </summary>
    public partial class addShift : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public addShift()
        {
            InitializeComponent();
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

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            int id_day;
            int id_time;
           
            if (calendar.SelectedDate == null)
                msg_lsb.Items.Add("Failure! Enter the date");
            else if (calendar.SelectedDate.Value.DayOfWeek.ToString() == "Friday" || calendar.SelectedDate.Value.DayOfWeek.ToString() == "Saturday")
                msg_lsb.Items.Add("Failure! The Pizza doesn't work on this day");
            else if (mornng_rdb.IsChecked == false && evnng_rdb.IsChecked == false)
                msg_lsb.Items.Add("Failure Enter the time");
            else if (emp == null)
                msg_lsb.Items.Add("Failure! Select the worker");
            else
            {
                if (mornng_rdb.IsChecked == true)
                {
                    id_time = 1;
                }
                else
                {
                    id_time = 2;
                }
                string day_of_week = calendar.SelectedDate.Value.DayOfWeek.ToString();
                DateTime dt = calendar.SelectedDate.Value;
                id_day = find_id_of_day(day_of_week);
                shift_day shd = db1.shift_day.ToArray()[id_day-1];
                shift_time sht = db1.shift_time.ToArray()[id_time-1];
                shift shift_emp = new shift {shift_day=shd,shift_time =sht,  shift_day_id =id_day, shift_time_id = id_time, employee = emp, date = dt, time_of_working =Convert.ToDecimal(0.00)};
                if (!IsAlreadyShift(shift_emp))
                {
                    this.db1.shift.Add(shift_emp);
                    this.db1.SaveChanges();
                    MessageBox.Show("The shift has been added", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The shift you want to add is already exist in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private bool IsAlreadyShift(shift shift_emp)
        {
            List<shift> l_sh = new List<shift>();
            l_sh = db1.shift.ToList();
            foreach (shift sh in l_sh)
            {
                if (shift_emp.date == sh.date && shift_emp.employee  == sh.employee &&shift_emp.shift_time==sh.shift_time )
                    return true;
            }
            return false;
        }

        private int find_id_of_day(string day_of_week)
        {
            List<shift_day> lst_shday = new List<shift_day>();
            lst_shday = db1.shift_day.ToList();
            foreach (shift_day shd in lst_shday)
            {
                if (shd.day == day_of_week)
                    return shd.Id;
            }
            return 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            List<employee> lst_e = new List<employee>();
            List<employee> employees = new List<employee>();
            lst_e = db1.employee.ToList();
            foreach (employee emp in lst_e)
            {
                if (emp.deleted == "exist")
                {
                    employees.Add(emp);
                }
            }
            emp_dtgrid.ItemsSource = employees;
        }
    }
}
