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
        employee emp = new employee();
        order ordr;
        products prod = new products();
        public newOrder(Database1Entities db1, employee emp,order ordr)
        {
            this.db1 = db1;
            this.ordr = ordr;
            this.emp = emp;
            InitializeComponent();
        }
        private int Calculating_price(string name, int i)
        {
            if (name.Contains("Penne"))
                return 37;
            else if (name.Contains("Quiche"))
                return 35;
            else if (name.Contains("Salad"))
                return 40;
            else if (name.Contains("rings"))
                return 20;
            else if (name.Contains("Personal"))
                return 22;
            else if (name.Contains("Family"))
                return 32;
            else if (name.Contains("Ziva"))
                return 22;
            else if (name.Contains("B_"))
                return 13;
            else if (name.Contains("-"))
                return 9;
            else if (name.Contains("+"))
                return 10;
            else if (name.Contains("Small"))
                return 55;
            else if (name.Contains("Large"))
                return 65 ;
            else if (name.Contains("Extra"))
                return 75;
            List<list_product> lstp =db1.list_product.ToList();
            int price = lstp[i].price;
            return price;

        }
        private void fd_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            List<products> lstp = db1.products.ToList();
            order_dtgrid.ItemsSource = lstp;
            string nm = food_cmbbx.Text;
            int qn = qnty_cmbbx.SelectedIndex + 1;
            int prc = 0;
            if (nm != "")
            {
                    if (nm == "Pizza")
                    {
                        if (dgh_type_cmbbx.Text != "" && size_cmbbx.Text != "")
                        {
                            string size = size_cmbbx.Text;
                            size = nm + " " + size;
                        List<list_product> lst_p = db1.list_product.ToList();
                        foreach (list_product lp in lst_p)
                        {
                            if (lp.name == size)
                            {
                                prc = lp.price;
                                break;
                            }
                        }
                            products products = new products { name = size, price = prc, quantity = qn, details = dgh_type_cmbbx.Text };
                            Pizza pz = new Pizza(qn, db1, order_dtgrid);
                            db1.products.Add(products);
                            db1.SaveChanges();
                            pz.ShowDialog();
                            order_dtgrid.ItemsSource = db1.products.ToList();
                            ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;

                    }
                }
                    else
                    {
                        List<list_product> lst_p = db1.list_product.ToList();
                        foreach (list_product lp in lst_p)
                        {
                            if (lp.name == nm)
                            {
                                prc = lp.price;
                                break;
                            }
                        }

                        products p = new products { name = nm, quantity = qn, price = prc };
                        db1.products.Add(p);
                        db1.SaveChanges();
                        order_dtgrid.ItemsSource = db1.products.ToList();
                        ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                    
                }
            }
            dgh_type_cmbbx.Visibility = Visibility.Hidden;
            dgh_type_cmbbx.SelectedIndex = -1;
            size_cmbbx.Visibility = Visibility.Hidden;
            size_cmbbx.SelectedIndex = -1;
            size_lbl.Visibility = Visibility.Hidden;
            dgh_type_lbl.Visibility = Visibility.Hidden;
            food_cmbbx.SelectedIndex = -1;
            qnty_cmbbx.SelectedIndex = 0;

        }

        private void food_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(food_cmbbx.SelectedItem== pizza)
            {
                dgh_type_cmbbx.Visibility = Visibility.Visible;
                size_cmbbx.Visibility = Visibility.Visible;
                size_lbl.Visibility = Visibility.Visible;
                dgh_type_lbl.Visibility = Visibility.Visible;
            }
            else
            {
                dgh_type_cmbbx.Visibility = Visibility.Hidden;
                size_cmbbx.Visibility = Visibility.Hidden;
                size_lbl.Visibility = Visibility.Hidden;
                dgh_type_lbl.Visibility = Visibility.Hidden;

            }
        }

        private void bvg_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            
            List<products> lstp = db1.products.ToList();
            order_dtgrid.ItemsSource = lstp;
            string nm = beverage_cmbbx.Text;
            if (nm != "")
            {
                int qn = qnty_cmbbx.SelectedIndex + 1;
                int prc = 0;
                List<list_product> lst_p = db1.list_product.ToList();
                foreach (list_product lp in lst_p)
                {
                    if (lp.name == nm)
                    {
                        prc = lp.price;
                        break;
                    }
                }
                //int i = food_cmbbx.Items.Count+ 2 + beverage_cmbbx.SelectedIndex;
                //prc = lst_p[i].price;
                products p = new products { name = nm, quantity = qn, price = prc };
                db1.products.Add(p);
                db1.SaveChanges();
                order_dtgrid.ItemsSource = db1.products.ToList();
                ////order_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            }
            beverage_cmbbx.SelectedIndex = -1;
            qnty_cmbbx.SelectedIndex = 0;
        }

        private void order_aply_btn_Click(object sender, RoutedEventArgs e)
        {
            if (discount_txb.Text != "")
            {
                string discount = discount_txb.Text;
                string notes = notes_txb.Text;
                ordr.notes = notes;
                invoice invc = new invoice(db1, order_dtgrid, emp,ordr, discount);
                invc.ShowDialog();
                
            }
        }

        private void order_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                prod = (products)order_dtgrid.SelectedItem;

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
                    db1.products.Remove(prod);
                    db1.SaveChanges();
                    order_dtgrid.ItemsSource = db1.products.ToList();

                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                for (int i = 0; i < food_cmbbx.Items.Count; i++)
                {
                    string name = food_cmbbx.Items[i].ToString();
                    name = name.Substring(38);
                    if (name == "Pizza")
                    {
                        for (int j = 0; j < size_cmbbx.Items.Count; j++)
                        {
                            name += " " + size_cmbbx.Items[j].ToString();
                            name = name.Remove(6,38);
                            List<list_product> lstp = new List<list_product>();
                            lstp = db1.list_product.ToList();
                            bool flg = true;
                            foreach (list_product lprod in lstp)
                            {
                                if (lprod.name == name)
                                    flg = false;

                            }
                            int pr = Calculating_price(name, i);
                            if (flg)
                            {
                                list_product lp = new list_product { name = name, price = pr , kind = "Food" };
                                db1.list_product.Add(lp);
                                db1.SaveChanges();
                            }
                            name = food_cmbbx.Items[i].ToString();
                            name = name.Substring(38);
                        }
                    i++;
                    }
                    name = food_cmbbx.Items[i].ToString();
                    name = name.Substring(38);
                List<list_product> lst_p = new List<list_product>();
                    lst_p = db1.list_product.ToList();
                    bool flag = true;
                    foreach (list_product lprod in lst_p)
                    {
                        if (lprod.name == name)
                            flag = false;

                    }
                    int prc = Calculating_price(name, i);
                    if (flag)
                    {
                        list_product lp = new list_product { name = name, price = prc, kind = "Food" };
                        db1.list_product.Add(lp);
                        db1.SaveChanges();
                    }
                }
                for (int i = 0; i < beverage_cmbbx.Items.Count; i++)
                {
                    string name = beverage_cmbbx.Items[i].ToString();
                    name = name.Substring(38);
                List<list_product> lst_p = new List<list_product>();
                    lst_p = db1.list_product.ToList();
                    bool flag = true;
                    foreach (list_product lprod in lst_p)
                    {
                        if (lprod.name == name)
                            flag = false;

                    }
                    int prc = Calculating_price(name, i);
                    if (flag)
                    {
                        list_product lp = new list_product { name = name, price = prc, kind = "Beverage" };
                        db1.list_product.Add(lp);
                        db1.SaveChanges();
                    }
                }
            List<list_product> lsp = new List<list_product>();
            lsp = db1.list_product.ToList();
            if (lsp.Count > 45)
            {
                for (int i = 45; i < lsp.Count; i++)
                {
                    if(lsp[i].kind == "Food")
                    {
                        food_cmbbx.Items.Add(lsp[i].name);
                    }
                    if(lsp[i].kind == "Beverage")
                    {
                        beverage_cmbbx.Items.Add(lsp[i].name);
                    }
                }
            }
        }
    }
}
