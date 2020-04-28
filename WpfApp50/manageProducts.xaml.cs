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
            int price=0;
            if (name_add_product.Text != "" && price_add_product.Text != "" && kind_add_product.SelectedItem != null)
            {
                string name = name_add_product.Text;
                price = Int32.Parse(price_add_product.Text);
                kind_product kp = db1.kind_product.ToArray()[kind_add_product.SelectedIndex];
                products lstp = new products { name = name, price = price, kind_product = kp, kind_product_id= kind_add_product.SelectedIndex+1};
                db1.products.Add(lstp);
                db1.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void product_change_btn_Click(object sender, RoutedEventArgs e)
        {
            int price = 0;
            if (name_chnge_product.Text != "" && price_chnge_product.Text != "" && pro!=null)
            {
                string name = name_chnge_product.Text;
                price = Int32.Parse(price_chnge_product.Text);
                pro.name = name;
                pro.price = price;
                db1.SaveChanges();
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
                pro = (products) product_dtgrid.SelectedItem;
                name_chnge_product.Text = pro.name;
                price_chnge_product.Text = pro.price.ToString();
            }
            catch
            {
                MessageBox.Show("you selected a non-existent product", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void price_chnge_product_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(price_chnge_product.Text, out a))
                price_chnge_product.Clear();
        }

        private void price_add_product_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(price_add_product.Text, out a))
                price_add_product.Clear();
        }
    }
}
