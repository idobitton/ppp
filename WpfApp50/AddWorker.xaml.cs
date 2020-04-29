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
                string gndr = "";
                if (num_id_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your id");
                else if (f_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your first name");
                else if (l_name_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your last name");
                else if (phne_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your phone");
                else if (p_code_txb.Text == "")
                    msg_lsb.Items.Add("Failure! Enter your postal code");
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
                    employee_type employee_Type = db1.employee_type.ToArray()[emp_cmbbx.SelectedIndex];
                postal_code postal_Code = new postal_code { postal_c = Convert.ToInt32(p_code_txb.Text), city = city_txb.Text, street = strt_txb.Text, house_number = Convert.ToInt32(house_num_txb.Text)};
                int number_id = 0;  
                number_id = Convert.ToInt32(num_id_txb.Text);
                employee employ = new employee {is_working_now = "not at shift" , deleted = "exist" , id_number = num_id_txb.Text, first_name = f_name_txb.Text, last_name = l_name_txb.Text, phone = phne_txb.Text, gender = gndr, employee_type_id = emp_cmbbx.SelectedIndex + 1, employee_type = employee_Type };
                db1.employee.Add(employ);
                employ.Id = Organize_employee_id();
                if (Checking_postal_code(postal_Code))
                {
                    List<postal_code> pc = new List<postal_code>();
                    pc = db1.postal_code.ToList();
                    foreach (postal_code p in pc)
                    {
                        if (p.postal_c == postal_Code.postal_c)
                        {
                            employ.postal_code_postal_c = p.postal_c;
                            employ.postal_code = p;
                        }
                    }
                }
                else
                {
                    db1.postal_code.Add(postal_Code);
                    employ.postal_code = postal_Code;
                    employ.postal_code_postal_c = Convert.ToInt32(p_code_txb.Text);
                }
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
        private bool Checking_postal_code(postal_code postal_Code)
        {
            List<postal_code> pc= new List<postal_code>();
            pc = db1.postal_code.ToList();
            foreach (postal_code p in pc)
            {
                if (p.postal_c == postal_Code.postal_c)
                    return true;
            }
            return false;
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
        //בדיקה שרק מספרים יכללו בתיבת הכתיבה
        private void phne_txb_KeyUp(object sender, KeyEventArgs e)
        {
                long a;
                if (!long.TryParse(phne_txb.Text, out a))
                    phne_txb.Clear();
        }

        private void p_code_txb_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(p_code_txb.Text, out a))
                p_code_txb.Clear();
        }
        private void house_num_txb_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(house_num_txb.Text, out a))
                house_num_txb.Clear();
        }

        private void num_id_txb_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(num_id_txb.Text, out a))
                num_id_txb.Clear();
        }
    }
}

