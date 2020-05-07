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
    /// Interaction logic for check.xaml
    /// </summary>
    public partial class check : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr;
        int discount;
        bool flg;
        bool delivery;
        public check(Database1Entities db1, DataGrid order_details_dtgrid, order ordr, string discount, bool delivery)
        {
            this.order_details_dtgrid = order_details_dtgrid;
            this.db1 = db1;
            this.discount = Convert.ToInt32(discount);
            this.ordr = ordr;
            this.flg = true;
            this.delivery = delivery;
            InitializeComponent();
        }
        private void cash_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            invoice_cash ic = new invoice_cash(db1,ordr,discount);
            ic.ShowDialog();
        }

        private void credit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            invoice_credit icr = new invoice_credit(db1, ordr, discount);
            icr.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (flg)
            {
                if (discount > 100)
                    discount = 100;
                double sp = 0;
                client_name_lbl.Content += ordr.client_details.first_name + " " + ordr.client_details.last_name;
                worker_name_lbl.Content += ordr.employee.first_name + " " + ordr.employee.last_name;
                notes_lbl.Content += ordr.notes;
                order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                List<order_details> lstp = db1.order_details.ToList();
                foreach (order_details p in lstp)
                {
                    sp += (p.products.price * p.quantity);
                }
                if (delivery)
                {
                    dlvr_lbl.Visibility = Visibility.Visible;
                    sp *=1.2;
                }
                int f_price = Convert.ToInt32(sp - (sp * discount) / 100);
                payment_name_lbl.Content += f_price.ToString() + "₪";
                dscnt_lbl.Content += discount.ToString() + "%";
                final_price fp = new final_price { s_price = Convert.ToInt32(sp), f_price = f_price };
                ordr.final_price = db1.final_price.Add(fp);
                ordr.final_price_s_price = Convert.ToInt32(sp);
                db1.order.Add(ordr);
                db1.SaveChanges();
                object row = new object();
                for (int i = 0; i < db1.final_price.ToList().Count; i++)
                {
                    row = db1.final_price.ToArray()[i];
                }
                List<object> lstrow = new List<object>
                {
                    row
                };
                fprice_dtgrid.ItemsSource = lstrow;
                fprice_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                fprice_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
                flg = false;
                List<products> lst_products = db1.products.ToList();
                List<order_details> lst_order_details = db1.order_details.ToList();
                List<products> lst_real_products = new List<products>();
                foreach(order_details ord in lst_order_details)
                {
                    foreach(products product in lst_products)
                    {
                        if (ord.products_id == product.Id)
                        {
                            lst_real_products.Add(product);
                            break;
                        }
                    }  
                }
                products_dtgrid.ItemsSource = lst_real_products;
                products_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
                products_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                products_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                products_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
                products_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
                products_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            }
        }
    }
}
