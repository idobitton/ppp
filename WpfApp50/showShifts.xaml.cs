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
        private void apply_Click(object sender, RoutedEventArgs e)
        {
            if (IsDate(date_txb.Text))
            {
                DateTime dt = DateTime.Parse(date_txb.Text);
                sun_eve_lsb.Background = Brushes.White;
                sun_mor_lsb.Background = Brushes.White;
                sun_mor_lsb.Items.Clear();
                sun_eve_lsb.Items.Clear();
                mon_mor_lsb.Items.Clear();
                mon_eve_lsb.Items.Clear();
                tue_mor_lsb.Items.Clear();
                tue_eve_lsb.Items.Clear();
                wed_mor_lsb.Items.Clear();
                wed_eve_lsb.Items.Clear();
                thu_mor_lsb.Items.Clear();
                thu_eve_lsb.Items.Clear();
                sunday_lbl.Content = "Sunday:";
                monday_lbl.Content = "Monday";
                tuesday_lbl.Content = "Tuesday";
                wednesday_lbl.Content = "Wednesday";
                thursday_lbl.Content = "Thursday";
                bool flg = true;
                switch (dt.DayOfWeek.ToString())
                {
                    case "Sunday":
                        sunday_lbl.Content += " " + dt.ToString("dd/MM/yyyy");
                        monday_lbl.Content += " " + dt.AddDays(1).ToString("dd/MM/yyyy");
                        tuesday_lbl.Content += " " + dt.AddDays(2).ToString("dd/MM/yyyy");
                        wednesday_lbl.Content += " " + dt.AddDays(3).ToString("dd/MM/yyyy");
                        thursday_lbl.Content += " " + dt.AddDays(4).ToString("dd/MM/yyyy");
                        break;
                    case "Monday":
                        try
                        {
                            sunday_lbl.Content += " " + dt.AddDays(-1).ToString("dd/MM/yyyy");
                        }
                        catch
                        {
                            sun_eve_lsb.Background = Brushes.Black;
                            sun_mor_lsb.Background = Brushes.Black;
                            sunday_lbl.Content += "--/--/----";
                        }
                        monday_lbl.Content += " " + dt.ToString("dd/MM/yyyy");
                        tuesday_lbl.Content += " " + dt.AddDays(1).ToString("dd/MM/yyyy");
                        wednesday_lbl.Content += " " + dt.AddDays(2).ToString("dd/MM/yyyy");
                        thursday_lbl.Content += " " + dt.AddDays(3).ToString("dd/MM/yyyy");
                        break;
                    case "Tuesday":
                        try
                        {
                            sunday_lbl.Content += " " + dt.AddDays(-2).ToString("dd/MM/yyyy");
                        }
                        catch
                        {
                            sun_eve_lsb.Background = Brushes.Black;
                            sun_mor_lsb.Background = Brushes.Black;
                            sunday_lbl.Content += "--/--/----";
                        }
                        monday_lbl.Content += " " + dt.AddDays(-1).ToString("dd/MM/yyyy");
                        tuesday_lbl.Content += " " + dt.ToString("dd/MM/yyyy");
                        wednesday_lbl.Content += " " + dt.AddDays(1).ToString("dd/MM/yyyy");
                        thursday_lbl.Content += " " + dt.AddDays(2).ToString("dd/MM/yyyy");
                        break;
                    case "Wednesday":
                        try
                        {
                            sunday_lbl.Content += " " + dt.AddDays(-3).ToString("dd/MM/yyyy");
                        }
                        catch
                        {
                            sun_eve_lsb.Background = Brushes.Black;
                            sun_mor_lsb.Background = Brushes.Black;
                            sunday_lbl.Content += "--/--/----";
                        }
                        monday_lbl.Content += " " + dt.AddDays(-2).ToString("dd/MM/yyyy");
                        tuesday_lbl.Content += " " + dt.AddDays(-1).ToString("dd/MM/yyyy");
                        wednesday_lbl.Content += " " + dt.ToString("dd/MM/yyyy");
                        thursday_lbl.Content += " " + dt.AddDays(1).ToString("dd/MM/yyyy");
                        break;
                    case "Thursday":
                        try
                        {
                            sunday_lbl.Content += " " + dt.AddDays(-4).ToString("dd/MM/yyyy"); 
                        }
                        catch
                        {
                            sun_eve_lsb.Background = Brushes.Black;
                            sun_mor_lsb.Background = Brushes.Black;
                            sunday_lbl.Content += "--/--/----";
                        }
                        monday_lbl.Content += " " + dt.AddDays(-3).ToString("dd/MM/yyyy");
                        tuesday_lbl.Content += " " + dt.AddDays(-2).ToString("dd/MM/yyyy");
                        wednesday_lbl.Content += " " + dt.AddDays(-1).ToString("dd/MM/yyyy");
                        thursday_lbl.Content += " " + dt.ToString("dd/MM/yyyy");
                        break;
                    case "Friday":
                        flg = false;
                        MessageBox.Show("Failure! the pizza doesn't/didn't/won't work on this day", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    case "Saturday":
                        flg = false;
                        MessageBox.Show("Failure! the pizza doesn't/didn't/won't work on this day", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
                if (flg)
                {
                    List<shift> lst_shift = db1.shift.ToList();
                    string sunday_date = sunday_lbl.Content.ToString().Substring(sunday_lbl.Content.ToString().IndexOf(" ")+1);
                    string monday_date = monday_lbl.Content.ToString().Substring(monday_lbl.Content.ToString().IndexOf(" ")+1);
                    string tuesday_date = tuesday_lbl.Content.ToString().Substring(tuesday_lbl.Content.ToString().IndexOf(" ")+1);
                    string wednesday_date = wednesday_lbl.Content.ToString().Substring(wednesday_lbl.Content.ToString().IndexOf(" ")+1);
                    string thursday_date = thursday_lbl.Content.ToString().Substring(thursday_lbl.Content.ToString().IndexOf(" ")+1);
                    foreach (shift sh in lst_shift)
                    {
                        string shift_date = sh.date.ToString("dd/MM/yyyy");
                        if (shift_date == sunday_date)
                        {
                            if (sh.shift_time.time == "Morning")
                                sun_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                            else
                                sun_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);

                        }
                        if (shift_date == monday_date)
                        {
                            if (sh.shift_time.time == "Morning")
                                mon_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                            else
                                mon_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                        }
                        if (shift_date == tuesday_date)
                        {
                            if (sh.shift_time.time == "Morning")
                                tue_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                            else
                                tue_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);

                        }
                        if (shift_date == wednesday_date)
                        {
                            if (sh.shift_time.time == "Morning")
                                wed_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                            else
                                wed_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);

                        }
                        if (shift_date == thursday_date)
                        {
                            if (sh.shift_time.time == "Morning")
                                thu_mor_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                            else
                                thu_eve_lsb.Items.Add(sh.employee.first_name + " " + sh.employee.last_name);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("you didn't insert a date according to the form (dd/mm/yyyy)", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
