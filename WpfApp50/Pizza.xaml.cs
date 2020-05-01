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
            order_details details_order = new order_details();
            name = extra_cmbbx.Text;
            details = location_cmbbx.Text;
            if (name != "" && details != "")
            {
                List<products> lst_p = db1.products.ToList();
                foreach (products lp in lst_p)
                {
                    if (lp.name == name)
                    {
                        details_order.products_id = lp.Id;
                        break;
                    }
                }
                details_order.quantity = quantity;
                details_order.details = details = details + ", " + notes_txb.Text;
                db1.order_details.Add(details_order);
                dataGrid.ItemsSource = db1.order_details.ToList();
                db1.SaveChanges();
                this.Close();
            }
            else
            {
                if (name == "")
                {
                    extra_lbl.Foreground = Brushes.Red;
                    if (details == "")
                        location_lbl.Foreground = Brushes.Red;
                    else
                        location_lbl.Foreground = Brushes.Black;
                }
                else
                {
                    extra_lbl.Foreground = Brushes.Black;
                    if (details == "")
                        location_lbl.Foreground = Brushes.Red;
                }
            }
        }

        private void add_extra_Click(object sender, RoutedEventArgs e)
        {
            order_details details_order = new order_details();
            name = extra_cmbbx.Text;
            details = location_cmbbx.Text;
            if (name != "" && details != "")
            {
                List<products> lst_p = db1.products.ToList();
                foreach (products lp in lst_p)
                {
                    if (lp.name == name)
                    {
                        details_order.products_id = lp.Id;
                        break;
                    }
                }
                details_order.quantity = quantity;
                details_order.details = details = details + ", " + notes_txb.Text;
                db1.order_details.Add(details_order);
                dataGrid.ItemsSource = db1.order_details.ToList();
                db1.SaveChanges();
                MessageBox.Show("The Extra was added", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                extra_cmbbx.SelectedIndex = -1;
                location_cmbbx.SelectedIndex = -1;
                notes_txb.Text = "";
                extra_lbl.Foreground = Brushes.Black;
                location_lbl.Foreground = Brushes.Black;
            }
            else
            {
                if (name == "")
                {
                    extra_lbl.Foreground = Brushes.Red;
                    if (details == "")
                        location_lbl.Foreground = Brushes.Red;
                    else
                        location_lbl.Foreground = Brushes.Black;
                }
                else
                {
                    extra_lbl.Foreground = Brushes.Black;
                    if (details == "")
                        location_lbl.Foreground = Brushes.Red;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<products> lsp = db1.products.ToList();
                for (int i = 1; i < lsp.Count; i++)
                {
                    if (lsp[i].kind_product_id == 3 && lsp[i].client_or_supplier.identity != "Supplier")
                    {
                        extra_cmbbx.Items.Add(lsp[i].name);
                    }
                }
        }
    }
}
