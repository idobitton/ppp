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
    /// Interaction logic for Pizza.xaml
    /// </summary>
    public partial class Pizza : Window
    {
        Database1Entities db1 = new Database1Entities();
        DataGrid dataGrid = new DataGrid();
        private int quantity;
        private string name;
        private int price = 10;
        private string details;
        List<ComboBoxItem> lcmbbxi = new List<ComboBoxItem>();
        public Pizza(int quantity, Database1Entities db1, DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
            this.db1 = db1;
            this.quantity = quantity;
            InitializeComponent();
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {

            name = extra_cmbbx.Text;
            details = location_cmbbx.Text;
            if (name != "" && details != "")
            {
                if (name == "Nothing")
                    price = 0;
                List<list_product> lst_p = db1.list_product.ToList();
                foreach (list_product lp in lst_p)
                {
                    if (lp.name == name)
                    {
                        price = lp.price;
                        break;
                    }
                }
                products products = new products { name = name, price = price, quantity = quantity, details = details + ", " + notes_txb.Text };
                db1.products.Add(products);
                dataGrid.ItemsSource = db1.products.ToList();
                db1.SaveChanges();
                this.Close();
            }
        }

        private void add_extra_Click(object sender, RoutedEventArgs e)
        {
            name = extra_cmbbx.Text;
            details = location_cmbbx.Text;
            if (name != "" && details != "")
            {
                if (name == "Nothing")
                    price = 0;
                List<list_product> lst_p = db1.list_product.ToList();
                foreach (list_product lp in lst_p)
                {
                    if (lp.name == name)
                    {
                        price = lp.price;
                        break;
                    }
                }
                products products = new products { name = name, price = price, quantity = quantity, details = details + ", " + notes_txb.Text};
                db1.products.Add(products);
                dataGrid.ItemsSource = db1.products.ToList();
                db1.SaveChanges();
            }
            extra_cmbbx.SelectedIndex = -1;
            location_cmbbx.SelectedIndex = -1;
            notes_txb.Text = "";
            MessageBox.Show("The Extra was added", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<list_product> lsp = new List<list_product>();
            lsp = db1.list_product.ToList();
                for (int i = 1; i < lsp.Count; i++)
                {
                    if (lsp[i].kind_product_id == 3)
                    {
                        extra_cmbbx.Items.Add(lsp[i].name);
                    }
                }
        }
    }
}
