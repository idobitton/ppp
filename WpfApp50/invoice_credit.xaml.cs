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
    /// Interaction logic for invoice_credit.xaml
    /// </summary>
    public partial class invoice_credit : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr = new order();
        int discount;
        bool flg = false;
        credit_card crd = new credit_card();
        public invoice_credit(Database1Entities db1, order ordr, int discount)
        {
            this.db1 = db1;
            this.ordr = ordr;
            this.discount = discount;
            InitializeComponent();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            if(calendar.SelectedDate!=null && ccd_txb.Text!="" && cvv_txb.Text!= "")
            {
                if (calendar.SelectedDate.Value.Year > DateTime.Today.Year)
                {
                    flg = true;
                    crd.credit_card_number = ccd_txb.Text;
                    crd.cvv = Convert.ToInt32(cvv_txb.Text);
                    crd.expiration_date = Convert.ToDateTime(calendar.SelectedDate);
                    calendar.Visibility = Visibility.Collapsed;
                    expr_date_lbl.Content = "Expiration date: " + calendar.SelectedDate.Value.Month + "/" + calendar.SelectedDate.Value.Year;
                    cvv_lbl.Content = "Cvv: " + cvv_txb.Text;
                    ccd_lbl.Content = "Credit card number: ****" + ccd_txb.Text.ToString().Substring(ccd_txb.Text.ToString().Length - 4);
                    cvv_txb.Visibility = Visibility.Collapsed;
                    ccd_txb.Visibility = Visibility.Collapsed;
                    pay.Visibility = Visibility.Collapsed;
                }
                else if (calendar.SelectedDate.Value.Year == DateTime.Today.Year)
                {
                    if (calendar.SelectedDate.Value.Month > DateTime.Today.Month)
                    {
                        flg = true;
                        crd.credit_card_number = ccd_txb.Text;
                        crd.cvv = Convert.ToInt32(cvv_txb.Text);
                        crd.expiration_date = Convert.ToDateTime(calendar.SelectedDate);
                        expr_date_lbl.Content = "Expiration date: " + calendar.SelectedDate.Value.Month + "/" + calendar.SelectedDate.Value.Year;
                        ccd_lbl.Content = "Credit card number: ****" + ccd_txb.Text.ToString().Substring(ccd_txb.Text.ToString().Length - 4);
                    }
                    else
                    {
                        MessageBox.Show("The expiration date is illegal", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The expiration date is illegal", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rtn_mw_Click(object sender, RoutedEventArgs e)
        {
            if (flg)
                this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            product_dtgrid.ItemsSource = db1.order_details.ToList();
            dscnt_lbl.Content = "Discount: " + discount + "%";
            date_lbl.Content = "Date: " + ordr.date;
            client_name_lbl.Content = " Client name: " + ordr.client_details.first_name+ " " + ordr.client_details.last_name ;
            employee_name_lbl.Content = "Employee name: " + ordr.employee.first_name.ToString() + ordr.employee.last_name.ToString();
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
        private void cvv_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(cvv_txb.Text, out long a))
               cvv_txb.Clear();
        }

        private void ccd_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(ccd_txb.Text, out long a))
                ccd_txb.Clear();
        }
    }
}
