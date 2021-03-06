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
    /// Interaction logic for allWindow.xaml
    /// </summary>
    public partial class allOrder : Window
    {
        Database1Entities db1 = new Database1Entities();
        int sum;
        public allOrder(Database1Entities db1)
        {
            this.db1 = db1;
            this.sum = 0;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            c_or_s_dtgrid.ItemsSource = db1.client_or_supplier.ToList();
            client_dtgrid.ItemsSource = db1.client_details.ToList();
            ordr_dtgrid.ItemsSource = db1.order.ToList();
            price_dtgrid.ItemsSource = db1.final_price.ToList();
            expense_dtgrid.ItemsSource = db1.expense.ToList();
            emp_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[10].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[11].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[12].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[13].Visibility = Visibility.Collapsed;
            emp_dtgrid.Columns[14].Visibility = Visibility.Collapsed;
            price_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
            c_or_s_dtgrid.Columns[2].Visibility = Visibility.Collapsed;
            c_or_s_dtgrid.Columns[3].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[10].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[11].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[12].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[13].Visibility = Visibility.Collapsed;
            ordr_dtgrid.Columns[14].Visibility = Visibility.Collapsed;
            expense_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[4].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[5].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[6].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[7].Visibility = Visibility.Collapsed;
            client_dtgrid.Columns[8].Visibility = Visibility.Collapsed;
            List<order> lst_o = db1.order.ToList();
            List<final_price> lst_fp = db1.final_price.ToList();
            foreach (order o in lst_o)
            {
                if (o.c_or_s_id == 2)
                {
                    foreach (final_price fp in lst_fp)
                    {
                        if (o.Id == fp.Id)
                        {
                            sum -= fp.f_price;
                        }
                    }
                }
                else
                {
                    foreach (final_price fp in lst_fp)
                    {
                        if (o.Id == fp.Id)
                        {
                            sum += fp.f_price;
                        }
                    }
                }
            }
            List<expense> lst_exp = db1.expense.ToList();
            foreach (expense exp in lst_exp)
            {
                sum -= exp.price;
            }
            ac_bc_lbl.Content += sum.ToString() + "₪";
        }
    }
}
