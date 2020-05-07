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
    /// Interaction logic for allProducts.xaml
    /// </summary>
    public partial class allProducts : Window
    {
        Database1Entities db1 = new Database1Entities();
        public allProducts( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            prod_dtgrid.ItemsSource = db1.products.ToList();
            kind_prod_dtgrid.ItemsSource = db1.kind_product.ToList();
            c_or_s_dtgrid.ItemsSource = db1.client_or_supplier.ToList();
            prod_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            prod_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            prod_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            kind_prod_dtgrid.Columns[2].Visibility = Visibility.Collapsed;
            c_or_s_dtgrid.Columns[2].Visibility = Visibility.Collapsed;
            c_or_s_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
        }
    }
}
