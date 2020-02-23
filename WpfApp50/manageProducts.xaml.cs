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
                try
                {
                    price = Int32.Parse(price_add_product.Text);
                    kind_product kp = db1.kind_product.ToArray()[kind_add_product.SelectedIndex-1];
                    string kind = kind_add_product.Text;
                    list_product lstp = new list_product { name = name, price = price, kind_product = kp, kind_product_id= kind_add_product.SelectedIndex};
                    db1.list_product.Add(lstp);
                    db1.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("enter the price", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void price_change_btn_Click(object sender, RoutedEventArgs e)
        {
            bool flg = false;
            int price = 0;
            if (name_chnge_price.Text != "" && price_chnge_price.Text != "")
            {
                string name = name_chnge_price.Text;
                try
                {
                     price = Int32.Parse(price_chnge_price.Text);
                    List<list_product> lst_p = new List<list_product>();
                    lst_p = db1.list_product.ToList();
                    foreach (list_product p in lst_p)
                    {
                        if (p.name == name)
                        {
                            flg = true;
                            p.price = price;
                            db1.SaveChanges();
                            this.Close();
                        }
                    }
                    if(!flg)
                        MessageBox.Show("you wrote a non-existent product ", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch
                {
                    MessageBox.Show("enter the price", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
        }
    }
}
