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
    /// Interaction logic for manageWorkers.xaml
    /// </summary>
    public partial class manageWorkers : Window
    {
        Database1Entities db1 = new Database1Entities();
        public manageWorkers( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void add_worker_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddWorker addWorker = new AddWorker();
            addWorker.ShowDialog();
        }

        private void delete_worker_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DeleteWorker deleteWorker = new DeleteWorker(db1);
            deleteWorker.ShowDialog();
        }

        private void change_details_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            changeDetails cd = new changeDetails(db1);
            cd.ShowDialog();
        }
    }
}
