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
    /// Interaction logic for manageShifts.xaml
    /// </summary>
    public partial class manageShifts : Window
    {
        Database1Entities db1 = new Database1Entities();
        public manageShifts( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void add_shift_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            addShift adsh = new addShift();
            adsh.ShowDialog();
        }

        private void edit_shift_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            editShift es = new editShift(db1);
            es.ShowDialog();
        }

        private void show_shifts_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            showShifts ss = new showShifts(db1);
            ss.ShowDialog();
        }
    }
}
