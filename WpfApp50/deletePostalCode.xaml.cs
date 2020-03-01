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
    /// Interaction logic for deletePostalCode.xaml
    /// </summary>
    public partial class deletePostalCode : Window
    {
        Database1Entities db1 = new Database1Entities();
        postal_code pc;
        public deletePostalCode(Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void dlt_pc_Click(object sender, RoutedEventArgs e)
        {
            List<employee> lst_e;
            lst_e = db1.employee.ToList();
            foreach (employee emp in lst_e)
            {
                if(emp.postal_code == pc)
                {
                    emp.postal_code = null;
                    db1.SaveChanges();
                }
            }
            db1.postal_code.Remove(pc);
            db1.SaveChanges();
            pc_dtgrid.ItemsSource = db1.postal_code.ToList();
        }

        private void pc_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                pc = (postal_code)pc_dtgrid.SelectedItem;
            }
            catch
            {
                MessageBox.Show("you selected a non-existent postal code", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pc_dtgrid.ItemsSource = db1.postal_code.ToList();
        }
    }
}
