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
    /// Interaction logic for showShifts.xaml
    /// </summary>
    public partial class showShifts : Window
    {
        Database1Entities db1 = new Database1Entities();
        public showShifts(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<shift> lst_shift = db1.shift.ToList();
            List<employee> lst_emp = db1.employee.ToList();
            foreach (shift sh in lst_shift)
            {
                if (sh.shift_day.day == "Sunday" && sh.shift_time.time == "Morning")
                {
                    sun_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Sunday" && sh.shift_time.time == "Evening")
                {
                    sun_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Monday" && sh.shift_time.time == "Morning")
                {
                    mon_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Monday" && sh.shift_time.time == "Evening")
                {
                    mon_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Tuesday" && sh.shift_time.time == "Morning")
                {
                    tue_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Tuesday" && sh.shift_time.time == "Evening")
                {
                    tue_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Wednesday" && sh.shift_time.time == "Morning")
                {
                    wed_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Wednesday" && sh.shift_time.time == "Evening")
                {
                    wed_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Thursday" && sh.shift_time.time == "Morning")
                {
                    thu_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
                else if(sh.shift_day.day == "Thursday" && sh.shift_time.time == "Evening")
                {
                    thu_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
