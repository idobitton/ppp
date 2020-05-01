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
    /// Interaction logic for payment_invoice_supplier.xaml
    /// </summary>
    public partial class payment_invoice_supplier : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr= new order();
        int discount;
        public payment_invoice_supplier( Database1Entities db1, order ordr, int discount)
        {
            this.ordr = ordr;
            this.db1 = db1;
            this.discount = discount;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            product_dtgrid.ItemsSource = db1.order_details.ToList();
            dscnt_lbl.Content = "Discount: " + discount + "%"; 
            date_lbl.Content = "Date: " + ordr.date;
            supplier_name_lbl.Content = "Supplier name: " + ordr.company_name;
            List<final_price> lsp = db1.final_price.ToList();
            foreach(final_price fp in lsp)
            {
                if(fp.Id == ordr.final_price_id)
                {
                    final_price_lbl.Content = "Final price: " + fp.f_price;
                    after_vat_lbl.Content = "Fixed price: " + fp.f_price * 1.17;
                    List<final_price> lstfp=  new List<final_price>();
                    lstfp.Add(fp);
                    fprice_dtgrid.ItemsSource = lstfp;
                }
            }
        }

        private void rtn_mw_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
