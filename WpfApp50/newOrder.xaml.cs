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
    /// Interaction logic for newOrder.xaml
    /// </summary>
    public partial class newOrder : Window
    {
        Database1Entities db1 = new Database1Entities();
        order ordr;
        order_details prod = new order_details();
        bool delivery;
        public newOrder(Database1Entities db1, order ordr, bool delivery)
        {
            this.db1 = db1;
            this.ordr = ordr;
            this.delivery = delivery;
            InitializeComponent();
        }
        private void fd_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            List<order_details> lstp = db1.order_details.ToList();
            order_details_dtgrid.ItemsSource = lstp;
            order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
            order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
            order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            string nm = food_cmbbx.Text;
            if (nm != ""&& qnty_txb.Text !="")
            {
                qnty_lbl.Foreground = Brushes.Black;
                food_lbl.Foreground = Brushes.Black;
                int qn = Convert.ToInt32(qnty_txb.Text);
                order_details details_order = new order_details();
                if (nm.Contains("Pizza"))
                {
                    if (dgh_type_cmbbx.Text != "")
                    {
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
                        details_order.quantity = qn;
                        details_order.details= dgh_type_cmbbx.Text + ", " + notes_txb.Text;
                        db1.order_details.Add(details_order);
                        db1.SaveChanges();
                        Pizza pz = new Pizza(qn, db1, order_details_dtgrid);
                        pz.ShowDialog();
                        order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                        order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                        order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                        order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                        dgh_type_cmbbx.Visibility = Visibility.Collapsed;
                        dgh_type_cmbbx.SelectedIndex = -1;
                        dgh_type_lbl.Visibility = Visibility.Collapsed;
                        food_cmbbx.SelectedIndex = -1;
                        qnty_txb.Clear();
                        notes_txb.Text = "";
                        dgh_type_lbl.Foreground = Brushes.Black;
                        qnty_lbl.Visibility = Visibility.Collapsed;
                        qnty_txb.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        dgh_type_lbl.Foreground = Brushes.Red;
                        
                    }
                }
                else
                {
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
                    details_order.quantity = qn;
                    details_order.details = notes_txb.Text;
                    db1.order_details.Add(details_order);
                    db1.SaveChanges();
                    order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                    order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                    order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                    order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                    dgh_type_cmbbx.Visibility = Visibility.Collapsed;
                    dgh_type_cmbbx.SelectedIndex = -1;
                    dgh_type_lbl.Visibility = Visibility.Collapsed;
                    food_cmbbx.SelectedIndex = -1;
                    qnty_txb.Clear();
                    notes_txb.Text = "";
                    dgh_type_lbl.Foreground = Brushes.Black;
                    qnty_lbl.Visibility = Visibility.Collapsed;
                    qnty_txb.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                if (nm != "")
                {
                    food_lbl.Foreground = Brushes.Black;
                    qnty_lbl.Foreground = Brushes.Red;
                    if (nm.Contains("Pizza"))
                    {
                        if (dgh_type_cmbbx.SelectedIndex == -1)
                            dgh_type_lbl.Foreground = Brushes.Red;
                        else
                            dgh_type_lbl.Foreground = Brushes.Black;
                    }
                }
                else
                {
                    food_lbl.Foreground = Brushes.Red;
                }
            }
        }

        private void food_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qnty_lbl.Visibility = Visibility.Visible;
            qnty_txb.Visibility = Visibility.Visible;
            qnty_lbl.Foreground = Brushes.Black;
            if (food_cmbbx.SelectedIndex != -1)
            {
                if (food_cmbbx.SelectedItem.ToString().Contains("Pizza"))
                {
                    dgh_type_cmbbx.Visibility = Visibility.Visible;
                    dgh_type_lbl.Visibility = Visibility.Visible;
                }
                else
                {
                    dgh_type_cmbbx.Visibility = Visibility.Collapsed;
                    dgh_type_lbl.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void bvg_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            string nm = beverage_cmbbx.Text;
            if (nm != "" && qnty_txb.Text !="")
            {
                int qn = Convert.ToInt32(qnty_txb.Text);
                List<products> lst_p = db1.products.ToList();
                order_details details_order = new order_details();
                foreach (products prod in lst_p)
                {
                    if (prod.name == nm)
                    {
                        details_order.products_id = prod.Id;
                        break;
                    }
                }
                details_order.details = notes_txb.Text;
                details_order.quantity = qn;
                db1.order_details.Add(details_order);
                db1.SaveChanges();
                order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                beverage_cmbbx.SelectedIndex = -1;
                qnty_txb.Clear();
                notes_txb.Text = "";
                qnty_lbl.Foreground = Brushes.Black;
                beverage_lbl.Foreground = Brushes.Black;
                qnty_lbl.Visibility = Visibility.Collapsed;
                qnty_txb.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (nm != "")
                    qnty_lbl.Foreground = Brushes.Red;
                else
                    beverage_lbl.Foreground = Brushes.Red;
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
                if (discount_txb.Text != "")
                {
                    string discount = discount_txb.Text;
                    string notes = notes_txb.Text;
                    ordr.notes = notes;
                    ordr.date = DateTime.Now;
                    this.Close();
                    check chk = new check(db1, order_details_dtgrid, ordr, discount, delivery);
                    chk.ShowDialog();
                }
            }
        }

        private void order_details_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                prod = (order_details)order_details_dtgrid.SelectedItem;

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
                if (prod.products!= null && prod.products.name != null)
                {
                    db1.order_details.Remove(prod);
                    db1.SaveChanges();
                    order_details_dtgrid.ItemsSource = db1.order_details.ToList();
                    order_details_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
                    order_details_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                    order_details_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("you selected a non-existent product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("you selected a non-existent product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<products> lsp = db1.products.ToList();
            for (int i = 0; i < lsp.Count; i++)
            {
                if (lsp[i].kind_product_id == 1 && lsp[i].client_or_supplier.identity != "Supplier" )
                {
                    food_cmbbx.Items.Add(lsp[i].name);
                }
            }
            for (int i = 0; i<lsp.Count; i++)
            {
               if (lsp[i].kind_product_id == 2 && lsp[i].client_or_supplier.identity != "Supplier")
               {
                   beverage_cmbbx.Items.Add(lsp[i].name);
               }
            }
            products_dtgrid.ItemsSource = db1.products.ToList();
            products_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
            products_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
            products_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            products_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            products_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            products_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
        }
        private void qnty_txb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(qnty_txb.Text, out long _))
                qnty_txb.Clear();
        }

        private void beverage_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qnty_txb.Visibility = Visibility.Visible;
            qnty_lbl.Visibility = Visibility.Visible;
        }

        private void discount_txb_KeyUp(object sender, KeyEventArgs e)
        {
                if (!long.TryParse(discount_txb.Text, out long _))
                   discount_txb.Clear();
        }
    }
}