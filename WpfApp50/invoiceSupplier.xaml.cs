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
    /// Interaction logic for invoiceSupplier.xaml
    /// </summary>
    public partial class invoiceSupplier : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr;
        int discount;
        bool flg;
        public invoiceSupplier(Database1Entities db1, DataGrid order_dtgrid, order ordr)
        {
            this.product_dtgrid = order_dtgrid;
            this.db1 = db1;
            this.ordr = ordr;
            this.flg = true;
            this.discount = 0;
            InitializeComponent();
        }
        //private int CalculatingDigits(int num)
        //{
        //    if (num > 10)
        //        return 1 + CalculatingDigits(num / 10);
        //    return 1;
        //}
        private int CalculatingDiscount(int price)// חישוב הנחה פרוגרסיבית
        {
            //int digits = CalculatingDigits(price);
            //int r_num=1;
            //int num_return;
            //for (int i = 0; i < digits; i++)
            //{
            //    r_num *= 10;
            //}
            //num_return = price - ((price * (quantity - 1) / r_num)*10);
            //return num_return;
            for (int i = 20000; i>0; i-=2000)
            {
                if (price > i)
                    return i / 1000;
            }
            return 0;
        }

        private void payment_btn_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (flg)
            {
                int sp = 0;
                supplier_name_lbl.Content += ordr.company_name;
                notes_lbl.Content += ordr.notes;
                product_dtgrid.ItemsSource = db1.order_details.ToList();
                ////product_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                ////product_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                ////product_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                List<order_details> lstp = db1.order_details.ToList();
                foreach (order_details p in lstp)
                {
                    sp += Convert.ToInt32(p.products.price/1.5 * p.quantity);
                }
                discount = CalculatingDiscount(sp);
                int f_price = sp - (sp * discount) / 100;
                payment_name_lbl.Content += f_price.ToString() + "₪";
                dscnt_lbl.Content += discount.ToString() + "%";
                final_price fp = new final_price { s_price = sp, f_price = f_price };
                ordr.final_price = db1.final_price.Add(fp);
                ordr.final_price_s_price = sp;
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
                ////fprice_dtgrid1.Columns[0].Visibility = Visibility.Collapsed;
                ////fprice_dtgrid1.Columns[3].Visibility = Visibility.Collapsed;
                ////fprice_dtgrid1.Columns[5].Visibility = Visibility.Collapsed;
                ////fprice_dtgrid1.Columns[6].Visibility = Visibility.Collapsed;
                flg = false;
            }
        }
    }
}
