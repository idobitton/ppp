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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp50
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database1Entities db1 = new Database1Entities();
        public MainWindow()
        {
            InitializeComponent();
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            emp_type_dtgrid.ItemsSource = db1.employee_type.ToList();
            emp_pcode_dtgrid.ItemsSource = db1.postal_code.ToList();
            startClock();
        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += tickEvent;
            timer.Start();
        }

        private void tickEvent(object sender, EventArgs e)
        {
            datetime_lbl.Content = DateTime.Now.ToString("MM/dd/yyyy , hh:mm:ss , dddd");
        }

        private void new_ordr_btn_Click(object sender, RoutedEventArgs e)
        {
                names names = new names(emp_dtgrid, db1);
                names.ShowDialog();
        }
        private void ext_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void expenses_btn_Click(object sender, RoutedEventArgs e)
        {
            newExpenses ne = new newExpenses(db1);
            ne.ShowDialog();
        }

        private void ordr_supplier_btn_Click(object sender, RoutedEventArgs e)
        {
            List<products> lst_p;
            lst_p = db1.products.ToList();
            foreach (products p in lst_p)
            {
                db1.products.Remove(p);
                db1.SaveChanges();
            }
            orderSupplier op = new orderSupplier(db1);
            op.ShowDialog();
        }

        private void shifts_btn_Click(object sender, RoutedEventArgs e)
        {
            manageShifts ms = new manageShifts(db1);
            ms.ShowDialog();
        }

        private void all_ordr_btn_Click(object sender, RoutedEventArgs e)
        {
            allOrder ao = new allOrder(db1);
            ao.ShowDialog();
        }

        private void products_btn_Click(object sender, RoutedEventArgs e)
        {
            allProducts ap = new allProducts(db1);
            ap.ShowDialog();
        }

        private void Managing_products_btn_Click(object sender, RoutedEventArgs e)
        {
            manageProducts mp = new manageProducts(db1);
            mp.ShowDialog();
        }

        private void manage_workers_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manageWorkers mw = new manageWorkers(db1);
            mw.ShowDialog();
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            emp_pcode_dtgrid.ItemsSource = db1.postal_code.ToList();
            emp_type_dtgrid.ItemsSource = db1.employee_type.ToList();
            this.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db1.shift_day.Add(new shift_day { Id=1,day = "Sunday" });
            db1.shift_day.Add(new shift_day { Id = 2, day = "Monday" });
            db1.shift_day.Add(new shift_day { Id = 3, day = "Tuesday" });
            db1.shift_day.Add(new shift_day { Id = 4 ,day = "Wednesday" });
            db1.shift_day.Add(new shift_day { Id = 5,day = "Thursday" });
            db1.shift_time.Add(new shift_time { Id=1 ,time = "Morning" });
            db1.shift_time.Add(new shift_time { Id =2 ,time = "Evening" });
            db1.client_or_supplier.Add(new client_or_supplier { Id = 1, identity = "Client" });
            db1.client_or_supplier.Add(new client_or_supplier { Id = 2, identity = "Supplier" });
            db1.kind_product.Add(new kind_product { Id = 1, kind = "Food" });
            db1.kind_product.Add(new kind_product { Id = 1, kind = "Beverage" });
            db1.kind_product.Add(new kind_product { Id = 1, kind = "Extra" });
            db1.deleted.Add(new deleted { Id = 1, remove = "No" });
            db1.deleted.Add(new deleted { Id = 2, remove = "Yes" });
            db1.employee_type.Add(new employee_type { type = "Manager", salaryperhour = 120 });
            db1.employee_type.Add(new employee_type { type = "Chef", salaryperhour = 32 });
            db1.employee_type.Add(new employee_type { type = "Shift manager", salaryperhour = 38 });
            db1.employee_type.Add(new employee_type { type = "Cashier", salaryperhour = 29 });
            db1.employee_type.Add(new employee_type { type = "Delivery person", salaryperhour = 29 });
            db1.employee_type.Add(new employee_type { type ="Dishwasher", salaryperhour = 29 });
            db1.SaveChanges();
            ////emp_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[9].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[10].Visibility = Visibility.Collapsed;
            ////emp_type_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
            ////emp_type_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
            ////emp_pcode_dtgrid.Columns[0].Visibility = Visibility.Collapsed;
            ////emp_pcode_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
        }
    }
}
