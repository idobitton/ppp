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
    /// Interaction logic for newExpenses.xaml
    /// </summary>
    public partial class newExpenses : Window
    {
        Database1Entities db1 = new Database1Entities();
        employee emp;
        public newExpenses( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            string p_method;
            if (name_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter the name of the expense");
            else if (price_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter the price of the expense");
            else if (emp == null)
                msg_lsb.Items.Add("Failure! Select your identity");
            else if (pay_mth_cmbbx.SelectedItem == null)
                msg_lsb.Items.Add("Failure! Select the payment method");
            else
            {
                if (pay_mth_cmbbx.SelectedItem == credit)
                    p_method = "credit";
                else
                    p_method = "cash";

                DateTime dt = DateTime.Now;
                expense expnse = new expense { date = dt, employee= emp, name = name_txb.Text, pay_method = p_method, price = Convert.ToInt32(price_txb.Text)};
                db1.expense.Add(expnse);
                db1.SaveChanges();
                expense_dtgrid.Visibility = Visibility.Visible;
                expense_dtgrid.ItemsSource = db1.expense.ToList();
                ////expense_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
                ////expense_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
                ////expense_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
                ////expense_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expense_dtgrid.Visibility = Visibility.Collapsed;
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            List<employee> lst_e;
            List<employee> employees = new List<employee>();
            lst_e = db1.employee.ToList();
            foreach (employee emp in lst_e)
            {
                if (emp.deleted == "exist" && emp.is_working_now == "at shift")
                {
                    employees.Add(emp);
                }
            }
            emp_dtgrid.ItemsSource = employees;
            ////emp_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[9].Visibility = Visibility.Collapsed;
            ////emp_dtgrid.Columns[10].Visibility = Visibility.Collapsed;
        }
        private void emp_dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                emp = (employee)emp_dtgrid.SelectedItem;

            }
            catch
            {
                MessageBox.Show("you selected a non-existent employee", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void price_txb_KeyUp(object sender, KeyEventArgs e)
        {
            long a;
            if (!long.TryParse(price_txb.Text, out a))
                price_txb.Clear();
        }
    }
}
