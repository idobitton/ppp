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
    /// Interaction logic for changeDetails.xaml
    /// </summary>
    public partial class changeDetails : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public changeDetails(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void emp_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                emp = (employee)emp_dtgrid.SelectedItem;
                num_id_txb.Text = emp.id_number;
                f_name_txb.Text = emp.first_name;
                l_name_txb.Text = emp.last_name;
                phne_txb.Text = emp.phone;
                city_txb.Text = emp.postal_code.city;
                strt_txb.Text = emp.postal_code.street;
                house_num_txb.Text = emp.postal_code.house_number;
                slph_txb.Text = emp.employee_type.salaryperhour.ToString();
                if (emp.gender == "male")
                    male_rdb.IsChecked = true;
                else
                    female_rdb.IsChecked = true;
                if (emp.employee_type.type == "Manager")
                    emp_cmbbx.SelectedIndex = 0;
                else if (emp.employee_type.type == "Chef")
                    emp_cmbbx.SelectedIndex = 1;
                else if (emp.employee_type.type == "Shift manager")
                    emp_cmbbx.SelectedIndex = 2;
                else if (emp.employee_type.type == "Cashier")
                    emp_cmbbx.SelectedIndex = 3;
                else if (emp.employee_type.type == "Delivery person")
                    emp_cmbbx.SelectedIndex = 4;
                else
                    emp_cmbbx.SelectedItem = 5;
                if (emp.deleted_id == 1)
                    no_lsb.IsSelected = true;
                else
                    yes_lsb.IsSelected = true;
               

            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            if (emp != null)
            {
                int deleted = 0;
                int slryphour = 0;
                string gndr = "";
                if (num_id_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the id");
                else if (f_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your first name");
                else if (l_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your last name");
                else if (phne_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the phone");
                else if (slph_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the salary per hour");
                else if (city_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the city");
                else if (strt_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the street");
                else if (house_num_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter the house number");
                else if (female_rdb.IsChecked == false && male_rdb.IsChecked == false)
                    msg_lsb.Items.Add("Failure Enter the gender");
                else if (emp_cmbbx.SelectedItem == null)
                    msg_lsb.Items.Add("Failure! Select the Type");
                else
                {
                    if (male_rdb.IsChecked == true)
                        gndr = "male";
                    else
                        gndr = "female";
                    slryphour = Int32.Parse(slph_txb.Text);
                    if (yes_lsb.IsSelected == true)
                    {
                        deleted = 1;
                    }
                    emp.id_number = num_id_txb.Text;
                    emp.first_name = f_name_txb.Text;
                    emp.last_name = l_name_txb.Text;
                    emp.phone = phne_txb.Text;
                    emp.gender = gndr;
                    emp.employee_type.type = emp_cmbbx.Text;
                    emp.employee_type.salaryperhour = slryphour;
                    emp.postal_code.city = city_txb.Text;
                    emp.postal_code.street = strt_txb.Text;
                    emp.postal_code.house_number = house_num_txb.Text;
                    deleted dlt = db1.deleted.ToArray()[deleted];
                    emp.deleted = dlt;
                    emp.deleted_id = deleted + 1;
                    try
                    {
                        this.db1.SaveChanges();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Failure! the number id of the worker is already existent in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                msg_lsb.Items.Add("Failure! Select the worker");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            ////emp_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[9].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[10].Visibility = Visibility.Collapsed;
            emp_type_dtgrid.ItemsSource = db1.employee_type.ToList();
            ////emp_type_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
            ////emp_type_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
            pcode_dtgrid.ItemsSource = db1.postal_code.ToList();
            ////pcode_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
            ////pcode_dtgrid.Columns[4].Visibility = Visibility.Collapsed;

        }
    }
}
