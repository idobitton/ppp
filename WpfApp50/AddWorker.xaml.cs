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
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        private Database1Entities db1 = new Database1Entities();
        public AddWorker()
        {
            InitializeComponent();
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int slryphour = 0;
                string gndr = "";
                if (num_id_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your id");
                else if (f_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your first name");
                else if (l_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your last name");
                else if (phne_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your phone");
                else if (city_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your city");
                else if (strt_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your street");
                else if (house_num_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your house number");
                else if (female_rdb.IsChecked == false && male_rdb.IsChecked == false)
                    msg_lsb.Items.Add("Failure Enter your gender");
                else if (emp_cmbbx.SelectedItem == null)
                    msg_lsb.Items.Add("Failure! Select your Type");
                else
                {
                    if (male_rdb.IsChecked == true)
                        gndr = "male";
                    else
                        gndr = "female";
                    if (emp_cmbbx.Text == "Manager")
                        slryphour = 120;
                    else if (emp_cmbbx.Text == "Chef")
                        slryphour = 32;
                    else if (emp_cmbbx.Text == "Shift manager")
                        slryphour = 38;
                    else
                        slryphour = 29;
                    employee_type employee_Type = db1.employee_type.Add(new employee_type { type = emp_cmbbx.Text, salaryperhour = slryphour });
                    postal_code postal_Code = db1.postal_code.Add(new postal_code { city = city_txb.Text, street = strt_txb.Text, house_number = house_num_txb.Text });
                    deleted dlt = db1.deleted.ToArray()[0];
                    employee employ = new employee { deleted = dlt, deleted_id=1, id_number = num_id_txb.Text, first_name = f_name_txb.Text, last_name = l_name_txb.Text,  phone = phne_txb.Text, gender = gndr, employee_type = employee_Type, postal_code = postal_Code };
                    db1.postal_code.Add(postal_Code);
                    db1.employee_type.Add(employee_Type);
                    db1.employee.Add(employ);
                    employ.Id = Organize_employee_id();
                    this.db1.SaveChanges();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Failure! the number id of the worker is already existent in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
        }

        private int Organize_employee_id()
        {
            int id = 1;
            List<employee> emp_lst = db1.employee.ToList();
            foreach (employee emp in emp_lst)
            {
                if (emp.Id != id)
                    return id;
                id++;
            }
            return id;
        }
    }
}
