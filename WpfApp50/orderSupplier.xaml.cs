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
    /// Interaction logic for orderSupplier.xaml
    /// </summary>
    public partial class orderSupplier : Window
    {
        Database1Entities db1 = new Database1Entities();
        order_details prod;
        order ordr = new order();
        public orderSupplier(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }
        private void fd_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            List<order_details> lstp = db1.order_details.ToList();
            order_dtgrid.ItemsSource = lstp;
            string nm = food_cmbbx.Text;
            string qnty = qnty_txb.Text;
            int qn =0;
            order_details details_order = new order_details();
            if (supplier_name_txb.Text != "")
            {
                supplier_name_lbl.Foreground = Brushes.Black;
                if (nm!= "" && qnty_txb.Text != "")
                {
                    qnty_lbl.Foreground = Brushes.Black;
                    food_lbl.Foreground = Brushes.Black;
                    List<products> lst_p = db1.products.ToList();
                    foreach (products prod in lst_p)
                    {
                        if (prod.name == nm)
                        {
                            details_order.products_id = prod.Id;
                            details_order.products = prod;
                            break;
                        }
                    }
                    qn = Convert.ToInt32(qnty_txb.Text);
                    string quantity = details_order.products.pack.ToString();
                    if (quantity == "8 units")
                        qn *= 8;
                    else if (quantity == "crates of 30")
                        qn *= 30;
                    else if (quantity == "4 units")
                        qn *= 4;
                    else
                        qn *= 1;
                    int prc = Convert.ToInt32(details_order.products.price / 1.5);//// למצוא דרך ל הכניס את המחיר החדש
                    details_order.details = notes_txb.Text;
                    details_order.quantity = qn;
                    db1.order_details.Add(details_order);
                    db1.SaveChanges();
                    order_dtgrid.ItemsSource = db1.order_details.ToList();
                    ////order_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                    ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                    //איפוס
                    food_cmbbx.SelectedIndex = -1;
                    qnty_txb.Clear();
                    qnty_lbl.Content = "Quantity:";
                    qnty_lbl.Foreground = Brushes.Black;
                    supplier_name_lbl.Foreground = Brushes.Black;
                    qnty_lbl.Visibility = Visibility.Collapsed;
                    qnty_txb.Visibility = Visibility.Collapsed;
                    notes_txb.Text = "";
                }
                else
                {
                    if (nm != "")
                    {
                        qnty_lbl.Foreground = Brushes.Red;
                        food_lbl.Foreground = Brushes.Black;
                    }
                    else
                        food_lbl.Foreground = Brushes.Red;
                }
            }
            else
            {
                supplier_name_lbl.Foreground = Brushes.Red;
                if (nm == "")
                    food_lbl.Foreground = Brushes.Red;
                else
                    food_lbl.Foreground = Brushes.Black;
                if (qnty == "")
                    qnty_lbl.Foreground = Brushes.Red;
                else
                    qnty_lbl.Foreground = Brushes.Black;
            }
        }

        private void food_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qnty_txb.Visibility = Visibility.Visible;
            qnty_lbl.Visibility = Visibility.Visible;
            qnty_lbl.Content = "Quantity:";
            qnty_lbl.Foreground = Brushes.Black;

            var fd = food_cmbbx.SelectedItem;
            order_details details_order = new order_details();
            List<products> lst_p = db1.products.ToList();
            if (fd != null)
            {
                foreach (products prod in lst_p)
                {
                    if (fd.ToString() == prod.name)
                    {
                        details_order.products_id = prod.Id;
                        details_order.products = prod;
                        qnty_lbl.Content += " " + details_order.products.pack;
                        break;
                    }
                }
            }
        }

        private void beverage_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qnty_lbl.Content = "Quantity:";
            qnty_lbl.Foreground = Brushes.Black;
            qnty_txb.Visibility = Visibility.Visible;
            qnty_lbl.Visibility = Visibility.Visible;
            var bv = beverage_cmbbx.SelectedItem;
            order_details details_order = new order_details();
            List<products> lst_p = db1.products.ToList();
            if (bv != null)
            {
                foreach (products prod in lst_p)
                {
                    if (bv.ToString() == prod.name)
                    {
                        details_order.products_id = prod.Id;
                        details_order.products = prod;
                        qnty_lbl.Content += " " + details_order.products.pack;
                        break;
                    }
                }
            }
        }

        private void bvg_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            List<order_details> lstp = db1.order_details.ToList();
            order_dtgrid.ItemsSource = lstp;
            string nm = beverage_cmbbx.Text;
            string qnty = qnty_txb.Text;
            order_details details_order = new order_details();
            if (supplier_name_txb.Text != "")
            {
                supplier_name_lbl.Foreground = Brushes.Black;
                if (nm != "" && qnty_txb.Text != "")
                {
                    qnty_lbl.Foreground = Brushes.Black;
                    beverage_lbl.Foreground = Brushes.Black;
                    List<products> lst_p = db1.products.ToList();
                    foreach (products prod in lst_p)
                    {
                        if (prod.name == nm)
                        {
                            details_order.products_id = prod.Id;
                            details_order.products = prod;
                            break;
                        }
                    }
                    int qn = (Convert.ToInt32(qnty_txb.Text)) * 24;
                    int prc = Convert.ToInt32(details_order.products.price / 1.5);
                    details_order.quantity = qn;
                    details_order.details = notes_txb.Text;
                    db1.order_details.Add(details_order);
                    db1.SaveChanges();
                    order_dtgrid.ItemsSource = db1.order_details.ToList();
                    ////order_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                    ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                    //איפוס
                    beverage_cmbbx.SelectedIndex = -1;
                    qnty_txb.Clear();
                    qnty_lbl.Content = "Quantity:";
                    qnty_lbl.Foreground = Brushes.Black;
                    beverage_lbl.Foreground = Brushes.Black;
                    supplier_name_lbl.Foreground = Brushes.Black;
                    qnty_lbl.Visibility = Visibility.Collapsed;
                    qnty_txb.Visibility = Visibility.Collapsed;
                    notes_txb.Text = "";
                }
                else
                {
                    if (nm != "")
                    {
                        qnty_lbl.Foreground = Brushes.Red;
                        beverage_lbl.Foreground = Brushes.Black;
                    }
                    else
                        beverage_lbl.Foreground = Brushes.Red;
                }
            }
            else
            {
                supplier_name_lbl.Foreground = Brushes.Red;
                if (nm == "")
                    beverage_lbl.Foreground = Brushes.Red;
                else
                    beverage_lbl.Foreground = Brushes.Black;
                if (qnty == "")
                    qnty_lbl.Foreground = Brushes.Red;
                else
                    qnty_lbl.Foreground = Brushes.Black;
            }
            
        }

        private void order_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            int sp = 0;
            List<order_details> lstp = db1.order_details.ToList();
            foreach (order_details p in lstp)
            {
                sp += (p.products.price * p.quantity);
            }
            if (sp == 0)
            {
                MessageBox.Show("you have not choose any product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string notes = notes_txb.Text;
                ordr.notes = notes;
                ordr.company_name = supplier_name_txb.Text;
                ordr.date = DateTime.Now;
                client_or_supplier client_Or_Supplier = db1.client_or_supplier.ToArray()[1];
                ordr.c_or_s_id = 2;
                ordr.client_or_supplier = client_Or_Supplier;
                checkSupplier chk = new checkSupplier(db1, order_dtgrid, ordr);
                chk.ShowDialog();
            }
        }

        private void order_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                prod = (order_details)order_dtgrid.SelectedItem;

            }
            catch
            {
                MessageBox.Show("you selected a non-existent product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dlt_btn_Click(object sender, RoutedEventArgs e)
        {
            if (prod != null)
            {
                if (prod.products.name != null)
                {
                    db1.order_details.Remove(prod);
                    db1.SaveChanges();
                    order_dtgrid.ItemsSource = db1.order_details.ToList();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<products> lsp = new List<products>();
            lsp = db1.products.ToList();
            for (int i = 0; i < lsp.Count; i++)
            {
                if (lsp[i].kind_product_id != 2 && lsp[i].client_or_supplier.identity != "Client")
                {
                    food_cmbbx.Items.Add(lsp[i].name);
                }
            }
            for (int i = 0; i < lsp.Count; i++)
            {
                if (lsp[i].kind_product_id == 2 && lsp[i].client_or_supplier.identity != "Client")
                {
                    beverage_cmbbx.Items.Add(lsp[i].name);
                }
            }
        }
        //בדיקה שרק מספרים יכללו בתיבת הכתיבה
        private void qnty_txb_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(qnty_txb.Text, out a))
                qnty_txb.Clear();
        }

    }
}
