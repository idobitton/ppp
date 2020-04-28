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
            Mw_update();
        }
        private void ext_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void expenses_btn_Click(object sender, RoutedEventArgs e)
        {
            newExpenses ne = new newExpenses(db1);
            ne.ShowDialog();
            Mw_update();
        }

        private void ordr_supplier_btn_Click(object sender, RoutedEventArgs e)
        {
            List<order_details> lst_p;
            lst_p = db1.order_details.ToList();
            foreach (order_details p in lst_p)
            {
                db1.order_details.Remove(p);
                db1.SaveChanges();
            }
            orderSupplier op = new orderSupplier(db1);
            op.ShowDialog();
            Mw_update();
        }

        private void shifts_btn_Click(object sender, RoutedEventArgs e)
        {
            manageShifts ms = new manageShifts(db1);
            ms.ShowDialog();
            Mw_update();
        }

        private void all_ordr_btn_Click(object sender, RoutedEventArgs e)
        {
            allOrder ao = new allOrder(db1);
            ao.ShowDialog();
            Mw_update();
        }

        private void products_btn_Click(object sender, RoutedEventArgs e)
        {
            allProducts ap = new allProducts(db1);
            ap.ShowDialog();
            Mw_update();
        }

        private void Manage_products_btn_Click(object sender, RoutedEventArgs e)
        {
            manageProducts mp = new manageProducts(db1);
            mp.ShowDialog();
            Mw_update();
        }


        private void manage_workers_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manageWorkers mw = new manageWorkers(db1);
            mw.ShowDialog();
            Mw_update();
            this.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db1.shift_day.Add(new shift_day { day = "Sunday" });
            db1.shift_day.Add(new shift_day { day = "Monday" });
            db1.shift_day.Add(new shift_day { day = "Tuesday" });
            db1.shift_day.Add(new shift_day { day = "Wednesday" });
            db1.shift_day.Add(new shift_day { day = "Thursday" });
            db1.shift_time.Add(new shift_time { time = "Morning" });
            db1.shift_time.Add(new shift_time { time = "Evening" });
            db1.client_or_supplier.Add(new client_or_supplier { identity = "Client" });
            db1.client_or_supplier.Add(new client_or_supplier { identity = "Supplier" });
            db1.kind_product.Add(new kind_product { kind = "Food" });
            db1.kind_product.Add(new kind_product { kind = "Beverage" });
            db1.kind_product.Add(new kind_product { kind = "Extra" });
            db1.employee_type.Add(new employee_type { type = "Manager", salary_per_hour = 120 });
            db1.employee_type.Add(new employee_type { type = "Chef", salary_per_hour = 32 });
            db1.employee_type.Add(new employee_type { type = "Shift manager", salary_per_hour = 38 });
            db1.employee_type.Add(new employee_type { type = "Cashier", salary_per_hour = 29 });
            db1.employee_type.Add(new employee_type { type = "Delivery person", salary_per_hour = 29 });
            db1.employee_type.Add(new employee_type { type ="Dishwasher", salary_per_hour = 29 });
            db1.products.Add(new products { name = "Pizza Small", price = 55, kind_product_id =1});
            db1.products.Add(new products { name = "Pizza Large", price = 65, kind_product_id =1});
            db1.products.Add(new products { name = "Pizza Extra Large", price = 75, kind_product_id =1});
            db1.products.Add(new products { name = "Penne cream sauce", price = 37, kind_product_id =1});
            db1.products.Add(new products { name = "Penne Alfredo", price = 37, kind_product_id =1});
            db1.products.Add(new products { name = "Penne Roze", price = 37, kind_product_id =1});
            db1.products.Add(new products { name = "Mushroom Quiche", price = 35, kind_product_id =1});
            db1.products.Add(new products { name = "Batata Quiche", price = 35, kind_product_id =1});
            db1.products.Add(new products { name = "Greek Salad", price = 40, kind_product_id =1});
            db1.products.Add(new products { name = "Nisuaz Salad", price = 40, kind_product_id =1});
            db1.products.Add(new products { name = "Onion rings", price = 20, kind_product_id =1});
            db1.products.Add(new products { name = "Personal garlic bread", price = 22, kind_product_id =1});
            db1.products.Add(new products { name = "Family garlic bread", price = 32, kind_product_id =1});
            db1.products.Add(new products { name = "Ziva", price = 22, kind_product_id =1});
            db1.products.Add(new products { name = "Water+", price = 10, kind_product_id =2});
            db1.products.Add(new products { name = "Water-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "B_Oranges", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Grapes", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Coke", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Diet_Coke", price =13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Zero_Coke", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Sprite", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Zero Sprite", price =13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Fanta", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "B_Fuze Tea", price = 13, kind_product_id =2});
            db1.products.Add(new products { name = "Coke-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Zero Coke-", price =9, kind_product_id =2});
            db1.products.Add(new products { name = "Diet Coke-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Fanta-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Oranges-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Grapes-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Sprite-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Zero Sprite-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Fuze Tea-", price = 9, kind_product_id =2});
            db1.products.Add(new products { name = "Green olives", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Black olives", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Tuna", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Corn", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Feta", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Batata", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Onion", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Mushrooms", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Pineapple", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Mozzarella", price = 10, kind_product_id =3});
            db1.products.Add(new products { name = "Green pepper", price = 10, kind_product_id =3});
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

        private void entry_systm_btn_Click(object sender, RoutedEventArgs e)
        {
            entrySystem ens = new  entrySystem(db1);
            ens.ShowDialog();
            Mw_update();
        }

        private void exit_systm_btn_Click(object sender, RoutedEventArgs e)
        {
            exitSystem exs = new exitSystem(db1);
            exs.ShowDialog();
            Mw_update();
        }
        private void Mw_update()
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            emp_pcode_dtgrid.ItemsSource = db1.postal_code.ToList();
            emp_type_dtgrid.ItemsSource = db1.employee_type.ToList();
        }

    }
}
