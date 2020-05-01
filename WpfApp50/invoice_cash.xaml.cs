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
    /// Interaction logic for invoice_cash.xaml
    /// </summary>
    public partial class invoice_cash : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr = new order();
        int discount;
        bool flg = false;
        public invoice_cash(Database1Entities db1, order ordr, int discount)
        {
            this.db1 = db1;
            this.ordr = ordr;
            this.discount = discount;
            InitializeComponent();
        }
        private void rtn_mw_Click(object sender, RoutedEventArgs e)
        {
            if (flg)
                this.Close();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            if (pyd_txb.Text != "")
            {
                chnge_lbl.Content = "Change: ";
                pyd_lbl.Content = "Pay: ";
                flg = true;
                int change;
                int payed = Convert.ToInt32(pyd_txb.Text);
                int fixed_price = Convert.ToInt32(after_vat_lbl.Content.ToString().Substring(after_vat_lbl.Content.ToString().IndexOf(":") + 2));
                if (payed<fixed_price)
                {
                    MessageBox.Show("The total is lower than the order's price", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    pyd_lbl.Content= "Pay: " + payed;
                    change = payed - fixed_price;
                    chnge_lbl.Content = "Change: " + change.ToString();
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            product_dtgrid.ItemsSource = db1.order_details.ToList();
            dscnt_lbl.Content = "Discount: " + discount + "%";
            date_lbl.Content = "Date: " + ordr.date;
            client_name_lbl.Content = " Client name: " + ordr.client_details.first_name+ " " + ordr.client_details.last_name ;
            employee_name_lbl.Content = "Employee name: " + ordr.employee.first_name.ToString()+ ordr.employee.last_name.ToString();
            List<final_price> lsp = db1.final_price.ToList();
            foreach (final_price fp in lsp)
            {
                if (fp.Id == ordr.final_price_id)
                {
                    final_price_lbl.Content = "Final price: " + fp.f_price;
                    after_vat_lbl.Content = "Fixed price: " + fp.f_price * 1.17;
                    List<final_price> lstfp = new List<final_price>();
                    lstfp.Add(fp);
                    fprice_dtgrid.ItemsSource = lstfp;
                }
            }
        }

        private void pyd_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(pyd_txb.Text, out long a))
                pyd_txb.Clear();
        }
    }
}
