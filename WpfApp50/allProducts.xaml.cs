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

        private void Window_Activated(object sender, EventArgs e)
        {
            prod_dtgrid.ItemsSource = db1.list_product.ToList();
        }
    }
}
