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
                if (emp.postal_code != null)
                {
                    p_code_txb.Text = emp.postal_code.postal_c.ToString();
                    city_txb.Text = emp.postal_code.city;
                    strt_txb.Text = emp.postal_code.street;
                    house_num_txb.Text = emp.postal_code.house_number.ToString();
                }
                slph_txb.Text = emp.employee_type.salary_per_hour.ToString();
                if (emp.gender == "male")
                    male_rdb.IsChecked = true;
                else
                    female_rdb.IsChecked = true;
                emp_cmbbx.Text = emp.employee_type.type;
                if (emp.deleted == "exist")
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
                if (yes_lsb.IsSelected == true)
                {
                    emp.deleted = "not exist";
                    emp.is_working_now = "not at shift";
                    db1.SaveChanges();
                    this.Close();
                }
                else
                {
                    emp.deleted = "exist";
                    int slryphour;
                    string gndr;
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
                    else if (p_code_txb.Text == "")
                        msg_lsb.Items.Add("Failure! Enter your postal code");
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
                        slryphour = Convert.ToInt32(slph_txb.Text);
                        emp.id_number = num_id_txb.Text;
                        emp.first_name = f_name_txb.Text;
                        emp.last_name = l_name_txb.Text;
                        emp.phone = phne_txb.Text;
                        emp.gender = gndr;
                        postal_code postal_Code = new postal_code { postal_c = Convert.ToInt32(p_code_txb.Text), city = city_txb.Text, street = strt_txb.Text, house_number = Convert.ToInt32(house_num_txb.Text)};
                        if (Checking_postal_code(postal_Code))
                        {
                            List<postal_code> pc = db1.postal_code.ToList();
                            foreach (postal_code p in pc)
                            {
                                if (p.postal_c == postal_Code.postal_c)
                                {
                                    emp.postal_code_postal_c = p.postal_c;
                                    emp.postal_code = p;
                                }
                            }
                        }
                        else
                        {
                            db1.postal_code.Add(postal_Code);
                            emp.postal_code = postal_Code;
                            emp.postal_code_postal_c = Convert.ToInt32(p_code_txb.Text);
                        }
                        if (slryphour != emp.employee_type.salary_per_hour)
                        {
                            employee_type emp_t = new employee_type { type = emp_cmbbx.Text, salary_per_hour = slryphour };

                            if (Checking_emp_t(emp_t))
                            {
                                List<employee_type> l_ept = db1.employee_type.ToList();
                                foreach (employee_type ept in l_ept)
                                {
                                    if (ept.salary_per_hour == emp_t.salary_per_hour && ept.type == emp_t.type)
                                    {
                                        emp.employee_type_id = ept.Id;
                                        emp.employee_type = ept;
                                    }
                                }
                            }
                            else
                            {
                                db1.employee_type.Add(emp_t);
                                db1.SaveChanges();
                                emp.employee_type_id = emp_t.Id;
                                emp.employee_type = emp_t;
                                db1.SaveChanges();
                            }
                        }
                        else
                        {
                            emp.employee_type = db1.employee_type.ToArray()[emp_cmbbx.SelectedIndex];
                            emp.employee_type_id = emp_cmbbx.SelectedIndex + 1;
                        }
                        if (emp.postal_code_postal_c != Convert.ToInt32(p_code_txb.Text))
                        {
                            emp.postal_code_postal_c = Convert.ToInt32(p_code_txb.Text);
                        }
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
            }
            else
            {
                msg_lsb.Items.Add("Failure! Select the worker");
            }
        }

        private bool Checking_emp_t(employee_type emp_t)
        {
            List<employee_type> l_ept = db1.employee_type.ToList();
            foreach (employee_type ept in l_ept)
            {
                if (ept.salary_per_hour == emp_t.salary_per_hour && ept.type == emp_t.type)
                    return true;
            }
            return false;
        }

        private bool Checking_postal_code(postal_code postal_Code)
        {
            List<postal_code> pc = db1.postal_code.ToList();
            foreach (postal_code p in pc)
            {
                if (p.postal_c == postal_Code.postal_c)
                    return true;
            }
            return false;
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
        private void emp_cmbbx_DropDownClosed(object sender, EventArgs e)
        {
            if (emp_cmbbx.Text == "Manager")
                slph_txb.Text = "120";
            else if (emp_cmbbx.Text == "Chef")
                slph_txb.Text = "32";
            else if (emp_cmbbx.Text == "Shift manager")
                slph_txb.Text = "38";
            else
                slph_txb.Text = "29";
        }
        private void phne_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(phne_txb.Text, out long a))
                phne_txb.Clear();
        }

        private void p_code_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(p_code_txb.Text, out long a))
                p_code_txb.Clear();
        }
        private void house_num_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(house_num_txb.Text, out long a))
                house_num_txb.Clear();
        }

        private void num_id_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(num_id_txb.Text, out long a))
                num_id_txb.Clear();
        }

        private void slph_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(slph_txb.Text, out long a))
                slph_txb.Clear();
        }
    }
}
