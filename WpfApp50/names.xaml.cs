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
    /// Interaction logic for names.xaml
    /// </summary>
    public partial class names : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp = new employee();
        client_details cd = new client_details();
        public names(DataGrid emp_dtgrid, Database1Entities db1)
        {
            this.emp_dtgrid = emp_dtgrid;
            this.db1 = db1;
            db1.SaveChanges();
            this.emp_dtgrid.ItemsSource = db1.employee.ToList();
            InitializeComponent();
        }

        private void cntue_Click(object sender, RoutedEventArgs e)
        {
            if (client_name_txb.Text != "" && emp.Id != 0)
            {
                List<order_details> lst_p = db1.order_details.ToList();
                foreach (order_details p in lst_p)
                {
                    db1.order_details.Remove(p);
                    db1.SaveChanges();
                }
                string c_name = client_name_txb.Text;
                cd.first_name = c_name.Substring(0, c_name.IndexOf(' ') + 1);
                cd.last_name = c_name.Remove(0, c_name.IndexOf(' ') + 1);
                if (dlvr.IsChecked == true)
                {
                    client_info clinf = new client_info(db1,cd );
                    clinf.ShowDialog();
                }
                db1.SaveChanges();
                client_or_supplier client_Or_Supplier = db1.client_or_supplier.ToArray()[0];
                order ordr = new order {c_or_s_id = 1, client_or_supplier = client_Or_Supplier, employee=emp, client_details=cd};
                newOrder newOrder = new newOrder(db1, ordr,dlvr.IsChecked==true );
                this.Close();
                newOrder.ShowDialog();
                lst_p = db1.order_details.ToList();
            }
        }

        private void emp_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                emp = (employee)emp_dtgrid.SelectedItem;
            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            List<employee> lst_e = db1.employee.ToList();
            List<employee> employees = new List<employee>();
            foreach (employee emp in lst_e)
            {
                if (emp.deleted == "exist" && emp.is_working_now == "at shift")
                {
                    employees.Add(emp);
                }
            }
            emp_dtgrid.ItemsSource = employees;
        }
    }
}