﻿using System;
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
    /// Interaction logic for checkSupplier.xaml
    /// </summary>
    public partial class checkSupplier : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr;
        int discount;
        bool flg;
        public checkSupplier(Database1Entities db1, DataGrid order_details_dtgrid, order ordr)
        {
            this.order_details_dtgrid = order_details_dtgrid;
            this.db1 = db1;
            this.ordr = ordr;
            this.flg = true;
            this.discount = 0;
            InitializeComponent();
        }
        private int CalculatingDiscount(int price)
        {
            for (int i = 20000; i > 0; i -= 2000)
            {
                if (price > i)
                    return i / 1000;
            }
            return 0;
        }

        private void payment_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            payment_invoice_supplier pis  = new payment_invoice_supplier(db1,ordr, discount);
            pis.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (flg)
            {
                int sp = 0;
                supplier_name_lbl.Content += ordr.company_name;
                notes_lbl.Content += ordr.notes;
                order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                List<order_details> lstp = db1.order_details.ToList();
                foreach (order_details p in lstp)
                {
                    sp += Convert.ToInt32(p.products.price / 1.5 * p.quantity);
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
                fprice_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                fprice_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
                flg = false;
                List<products> lst_products = db1.products.ToList();
                List<order_details> lst_order_details = db1.order_details.ToList();
                List<products> lst_real_products = new List<products>();
                foreach (order_details ord in lst_order_details)
                {
                    foreach (products product in lst_products)
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
