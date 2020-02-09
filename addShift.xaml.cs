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
            string time;
            string week;
            string day;
            if (week_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter the week");
            else if (mornng_rdb.IsChecked == false && evnng_rdb.IsChecked == false)
                msg_lsb.Items.Add("Failure Enter the time");
            else if (day_cmbbx.SelectedItem == null)
                msg_lsb.Items.Add("Failure! Select the day");
            else if (emp == null)
                msg_lsb.Items.Add("Failure! Select the worker");
            else
            {
                if (mornng_rdb.IsChecked == true)
                    time = mornng_rdb.Content.ToString();
                else
                    time = evnng_rdb.Content.ToString();
                week = week_txb.Text;
                day = day_cmbbx.Text;
                shift shift_emp = new shift { day = day, time = time, week = week, employee = emp};
                this.db1.shift.Add(shift_emp);
                this.db1.SaveChanges();
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
        }
    }
}
