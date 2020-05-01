﻿using System;
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

                calendar.SelectedDate = new DateTime(Convert.ToInt32(sh.date.ToString().Substring(7,4)),Convert.ToInt32(sh.date.ToString().Substring(3,2)),Convert.ToInt32(sh.date.ToString().Substring(0,2)));
                no_lsb.IsSelected = true;
                id_num_txb.Text = sh.employee.id_number;
                name_txb.Text = sh.employee.first_name +" "+ sh.employee.last_name;
                if (sh.shift_time.time == "Morning")
                    mornng_rdb.IsChecked = true;
                else
                    evnng_rdb.IsChecked = true;
            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            int time_id;
            int day_id;
            string num_id;
            string day_of_week = calendar.SelectedDate.Value.DayOfWeek.ToString();
            DateTime dt = calendar.SelectedDate.Value;
            day_id = find_id_of_day(day_of_week);
            if (sh != null)
            {
                if (yes_lsb.IsSelected == true)
                {
                    db1.shift.Remove(sh);
                    db1.SaveChanges();
                    this.Close();
                }
                if (mornng_rdb.IsChecked == false && evnng_rdb.IsChecked == false)
                    msg_lsb.Items.Add("Failure Enter the time");
                else if (calendar.SelectedDate == null)
                    msg_lsb.Items.Add("Failure! Select the date");
                else if (calendar.SelectedDate.Value.DayOfWeek.ToString() == "Friday" || calendar.SelectedDate.Value.DayOfWeek.ToString() == "Saturday")
                    msg_lsb.Items.Add("Failure! The Pizza doesn't work on this day");
                else
                {
                    if (mornng_rdb.IsChecked == true)
                    {
                        //if (dt.Hour != 8)
                            //dt.AddHours(-8);
                        time_id = 1;

                    }
                    else
                    {
                        //if (dt.Hour != 16)
                            //dt.AddHours(8);
                        time_id = 2;
                    }
                    shift_day shd = db1.shift_day.ToArray()[day_id - 1];
                    shift_time sht = db1.shift_time.ToArray()[time_id - 1];
                    num_id = id_num_txb.Text;
                    sh.date = dt;
                    sh.shift_day = shd;
                    sh.shift_day_id = day_id;
                    sh.shift_time = sht;
                    sh.shift_time_id = time_id;
                    MessageBox.Show("The shift has been changed", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    db1.SaveChanges();
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
    }
}
