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
    /// Interaction logic for allClients.xaml
    /// </summary>
    public partial class allClients : Window
    {
        Database1Entities db1 = new Database1Entities();
        public allClients( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client_dtgrid.ItemsSource = db1.client_details.ToList();
            client_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            credit_card_dtgrid.ItemsSource = db1.credit_card.ToList();
            credit_card_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
            postal_code_dtgrid.ItemsSource = db1.postal_code.ToList();
            postal_code_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
            postal_code_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
        }
    }
}
