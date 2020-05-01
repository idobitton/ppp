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
    /// Interaction logic for manageProducts.xaml
    /// </summary>
    public partial class manageProducts : Window
    {
        products pro;
        Database1Entities db1 = new Database1Entities();
        public manageProducts(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void add_product_btn_Click_1(object sender, RoutedEventArgs e)
        {
            int price;
            if (name_add_product.Text != "" && price_add_product.Text != "" && kind_add_product.SelectedItem != null && (add_sell.IsChecked == true || add_buy.IsChecked == true) && add_prd_pack_lsb.SelectedItem !=null)
            {
                if (checking_name(name_add_product.Text))
                {
                    string name = name_add_product.Text;
                    price = Convert.ToInt32(price_add_product.Text);
                    kind_product kp = db1.kind_product.ToArray()[kind_add_product.SelectedIndex];
                    client_or_supplier cl_or_sp = new client_or_supplier();
                    int i = 0;
                    if (add_sell.IsChecked == true)
                    {
                        if (add_buy.IsChecked == true)
                        {
                            i = 2;
                            cl_or_sp = db1.client_or_supplier.ToArray()[i];
                        }
                        else
                        {
                            i = 0;
                            cl_or_sp = db1.client_or_supplier.ToArray()[i];
                        }
                    }
                    else
                    {
                        if (add_buy.IsChecked == true)
                        {
                            i = 1;
                            cl_or_sp = db1.client_or_supplier.ToArray()[i];
                        }
                    }
                    products p = new products { name = name, price = price, kind_product = kp, kind_product_id = kind_add_product.SelectedIndex + 1, pack = add_prd_pack_lsb.SelectedItem.ToString().Substring(37), client_or_supplier = cl_or_sp, c_or_s_id = i + 1 };
                    db1.products.Add(p);
                    db1.SaveChanges();
                    MessageBox.Show("The product has been added", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The name of the product is already exist in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool checking_name(string text)
        {
            List<products> lst_p = db1.products.ToList();
            foreach (products p in lst_p)
            {
                if (text == p.name)
                    return false;
            }
            return true;
        }
        private void product_change_btn_Click(object sender, RoutedEventArgs e)
        {
            int price;
            if (pro!=null && name_chnge_product.Text != "" && price_chnge_product.Text != "" && kind_chnge_product.SelectedItem != null && (chnge_sell.IsChecked == true || chnge_buy.IsChecked == true) && change_prd_pack_lsb.SelectedItem != null)
            {
                string name = name_chnge_product.Text;
                price = Convert.ToInt32(price_chnge_product.Text);
                kind_product kp = db1.kind_product.ToArray()[kind_chnge_product.SelectedIndex];
                client_or_supplier cl_or_sp = new client_or_supplier();
                int i = 0;
                if (chnge_sell.IsChecked == true)
                {
                    if (chnge_buy.IsChecked == true)
                    {
                        i = 2;
                        cl_or_sp = db1.client_or_supplier.ToArray()[i];
                    }
                    else
                    {
                        i = 0;
                        cl_or_sp = db1.client_or_supplier.ToArray()[i];
                    }
                }
                else
                {
                    if (chnge_buy.IsChecked == true)
                    {
                        i = 1;
                        cl_or_sp = db1.client_or_supplier.ToArray()[i];
                    }
                }
                pro.name = name;
                pro.price = price;
                pro.kind_product = kp;
                pro.kind_product_id = kind_chnge_product.SelectedIndex + 1;
                pro.pack = change_prd_pack_lsb.SelectedItem.ToString().Substring(37);
                pro.client_or_supplier = cl_or_sp;
                pro.c_or_s_id = i + 1;
                db1.SaveChanges();
                MessageBox.Show("The product has been changed", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            product_dtgrid.ItemsSource = db1.products.ToList();
        }

        private void product_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                chnge_buy.IsChecked = false;
                chnge_sell.IsChecked = false;
                change_prd_pack_lsb.SelectedIndex = -1;
                pro = (products) product_dtgrid.SelectedItem;
                name_chnge_product.Text = pro.name;
                price_chnge_product.Text = pro.price.ToString();
                kind_chnge_product.SelectedIndex = pro.kind_product_id - 1;
                for (int i = 0; i < change_prd_pack_lsb.Items.Count; i++)
                {
                    if (change_prd_pack_lsb.Items[i].ToString().Substring(37) == pro.pack)
                    {
                        change_prd_pack_lsb.SelectedIndex = i;
                        break;
                    }
                }
                switch (pro.c_or_s_id)
                {
                    case 1:
                        chnge_sell.IsChecked = true;
                        break; 
                    case 2:
                        chnge_buy.IsChecked = true;
                        break;
                    case 3:
                        chnge_buy.IsChecked = true;
                        chnge_sell.IsChecked = true;
                        break;
                }

            }
            catch
            {
                MessageBox.Show("you selected a non-existent product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void price_chnge_product_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(price_chnge_product.Text, out long a))
                price_chnge_product.Clear();
        }

        private void price_add_product_KeyUp(object sender, KeyEventArgs e)
        {
            if (!long.TryParse(price_add_product.Text, out long a))
                price_add_product.Clear();
        }
    }
}