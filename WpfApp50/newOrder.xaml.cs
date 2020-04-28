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
            order_dtgrid.ItemsSource = lstp;
            string nm = food_cmbbx.Text;
            int prc = 0;
            if (nm != ""&& qnty_txb.Text !="")
            {
                qnty_lbl.Foreground = Brushes.Black;
                food_lbl.Foreground = Brushes.Black;
                int qn = Convert.ToInt32(qnty_txb.Text);

                if (nm.Contains("Pizza"))
                {
                    if (dgh_type_cmbbx.Text != "")
                    {
                        List<products> lst_p = db1.products.ToList();
                        foreach (products prod in lst_p)
                        {
                            if (prod.name == nm)
                            {
                                prc = prod.price;
                                break;
                            }
                        }
                        order_details order_details = new order_details { name = nm, price = prc, quantity = qn, details = dgh_type_cmbbx.Text + ", " + notes_txb.Text };
                        db1.order_details.Add(order_details);
                        db1.SaveChanges();
                        Pizza pz = new Pizza(qn, db1, order_dtgrid);
                        pz.ShowDialog();
                        order_dtgrid.ItemsSource = db1.order_details.ToList();
                        ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                        //איפוס
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
                            prc = prod.price;
                            break;
                        }
                    }
                    order_details p = new order_details { name = nm, quantity = qn, price = prc };
                    db1.order_details.Add(p);
                    db1.SaveChanges();
                    order_dtgrid.ItemsSource = db1.order_details.ToList();
                    ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                    //איפוס
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
                    food_lbl.Foreground = Brushes.Red;
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
                int prc = 0;
                List<products> lst_p = db1.products.ToList();
                foreach (products prod in lst_p)
                {
                    if (prod.name == nm)
                    {
                        prc = prod.price;
                        break;
                    }
                }
                order_details p = new order_details { name = nm, quantity = qn, price = prc, details = notes_txb.Text };
                db1.order_details.Add(p);
                db1.SaveChanges();
                order_dtgrid.ItemsSource = db1.order_details.ToList();
                ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                //איפוס
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
                sp += (p.price * p.quantity);
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
                    invoice invc = new invoice(db1, order_dtgrid, ordr, discount, delivery);
                    invc.ShowDialog();
                }
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
                if (prod.name != null)
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
                if (lsp[i].kind_product_id == 1)
                {
                    food_cmbbx.Items.Add(lsp[i].name);
                }
            }
            for (int i = 0; i<lsp.Count; i++)
            {
               if (lsp[i].kind_product_id == 2)
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

        private void beverage_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qnty_txb.Visibility = Visibility.Visible;
            qnty_lbl.Visibility = Visibility.Visible;
        }
    }
}