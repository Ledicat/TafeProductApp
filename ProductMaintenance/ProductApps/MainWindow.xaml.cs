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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;
        //Delivery charge and wrapping charge constants for easy modification
        const int DELIVERY_CHARGE = 25;
        const int WRAPPING_CHARGE = 5;
        const decimal GST_MULTIPLIER = 1.1m;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                totalChargeTextBlock.Text = Convert.ToString(cProduct.TotalPayment + DELIVERY_CHARGE);
                totalChargeWrapTextBlock.Text = Convert.ToString(cProduct.TotalPayment + DELIVERY_CHARGE + WRAPPING_CHARGE);
                totalChargeGSTTextBlock.Text = Convert.ToString((cProduct.TotalPayment + DELIVERY_CHARGE + WRAPPING_CHARGE) * GST_MULTIPLIER);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
            totalChargeWrapTextBlock.Text = "";
            totalChargeGSTTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
