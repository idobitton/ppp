﻿using System;
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
    /// Interaction logic for DeleteWorker.xaml
    /// </summary>
    public partial class DeleteWorker : Window
    {
        private Database1Entities db1 =  new Database1Entities();
        public DeleteWorker( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void dlt_worker_Click(object sender, RoutedEventArgs e)
        {
            bool flg = false;
            if (deleted_id_txb.Text != "")
            {
                List<employee> lst_emp = db1.employee.ToList();
                foreach (employee employee in lst_emp)
                {
                    if (employee.id_number == deleted_id_txb.Text)
                    {
                        if(employee.deleted =="exist")
                            flg = true;
                    }
                    
                }
                if (flg == false)
                    lstb.Items.Add("Failure! the worker does not exist or has already been deleted");
                else
                {
                    foreach (employee employee in lst_emp)
                    {
                        if (employee.id_number == deleted_id_txb.Text)
                        {
                            employee.deleted = "not exist";
                            employee.is_working_now ="not at shift";
                            db1.SaveChanges();
                            MessageBox.Show("The worker has been deleted", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
                }
            }
            else
                lstb.Items.Add("Failure! enter the id of the worker you want to delete");
        }
    }
}
