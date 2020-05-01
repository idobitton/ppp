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
    /// Interaction logic for client_info.xaml
    /// </summary>
    public partial class client_info : Window
    {
        Database1Entities db1 = new Database1Entities();
        client_details cd;
        public client_info( Database1Entities db1, client_details cd)
        {
            this.db1 = db1;
            this.cd = cd;
            InitializeComponent();
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            if (phne_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your phone");
            else if (p_code_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your postal code");
            else if (city_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your city");
            else if (strt_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your street");
            else if (house_num_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your house number");
            else
            {
                cd.phone = phne_txb.Text;
                postal_code postal_Code = new postal_code { postal_c = Convert.ToInt32(p_code_txb.Text), city = city_txb.Text, street = strt_txb.Text, house_number = Convert.ToInt32(house_num_txb.Text) };
                this.Close();
                if (Checking_postal_code(postal_Code))
                {
                    List<postal_code> pc = db1.postal_code.ToList();
                    foreach (postal_code p in pc)
                    {
                        if (p.postal_c == postal_Code.postal_c)
                        {
                            cd.postal_code_id = p.postal_c;
                            cd.postal_code = p;
                        }
                    }
                }
                else
                {
                    db1.postal_code.Add(postal_Code);
                    cd.postal_code = postal_Code;
                    cd.postal_code_id = Convert.ToInt32(p_code_txb.Text);
                }
                this.db1.SaveChanges();
            }
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

        private void phne_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(phne_txb.Text, out long a))
                phne_txb.Clear();
        }
    }
}

