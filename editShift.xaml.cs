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
    /// Interaction logic for editShift.xaml
    /// </summary>
    public partial class editShift : Window
    {
        Database1Entities db1 = new Database1Entities();
        shift sh;
        employee emp;
        employee_type ep_type;
        postal_code p_code;
        public editShift(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void emp_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            sh = new shift();
            try
            {
                sh = (shift)shift_dtgrid.SelectedItem;
                week_txb.Text = sh.week;
                no_lsb.IsSelected = true;
                id_num_txb.Text = sh.employee.id_number;
                name_txb.Text = sh.employee.name;
                if (sh.time == "Morning")
                    mornng_rdb.IsChecked = true;
                else
                    evnng_rdb.IsChecked = true;
                if (sh.day == "Sunday")
                    day_cmbbx.SelectedIndex = 0;
                else if (sh.day == "Monday")
                    day_cmbbx.SelectedIndex = 1;
                else if (sh.day == "Tuesday")
                    day_cmbbx.SelectedIndex = 2;
                else if (sh.day == "Wednesday")
                    day_cmbbx.SelectedIndex = 3;
                else if (sh.day == "Thursday")
                    day_cmbbx.SelectedIndex = 4;
                else
                    day_cmbbx.SelectedIndex = 5;
            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            string time;
            if (sh != null)
            {
                if (week_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the week");
                else if (mornng_rdb.IsChecked == false && evnng_rdb.IsChecked == false)
                    msg_lsb.Items.Add("Failure Enter the time");
                else if (day_cmbbx.SelectedItem == null)
                    msg_lsb.Items.Add("Failure! Select the day");
                else
                {
                    if (mornng_rdb.IsChecked == true)
                        time = mornng_rdb.Content.ToString();
                    else
                        time = evnng_rdb.Content.ToString();
                    string num_id = id_num_txb.Text;
                    string week = week_txb.Text;
                    string day = day_cmbbx.Text;
                    sh.day = day;
                    sh.employee.id_number = num_id;
                    sh.time = time;
                    sh.week = week;
                    db1.SaveChanges();
                    if(yes_lsb.IsSelected == true)
                    {
                        db1.shift.Remove(sh);
                        db1.SaveChanges();
                    }
                    this.Close();
                }
            }
            else
            {
                msg_lsb.Items.Add("Failure! Select the shift");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            shift_dtgrid.ItemsSource = db1.shift.ToList();
            ////shift_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
        }
    }
}
