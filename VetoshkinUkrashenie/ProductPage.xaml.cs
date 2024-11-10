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

namespace VetoshkinUkrashenie
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            var currentProduct = VetoshkinUkrashenieEntities.GetContext().Product.ToList();
            ProductListView.ItemsSource = currentProduct;
            SortProduct.SelectedIndex = 0;
            FilterProduct.SelectedIndex = 0;
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            var currentProduct = VetoshkinUkrashenieEntities.GetContext().Product.ToList();

            if (FilterProduct.SelectedIndex == 0)
            {
                currentProduct = currentProduct.Where(p => p.ProductCurrentDiscount >= 0 && p.ProductCurrentDiscount < 100).ToList();
            }

            if (FilterProduct.SelectedIndex == 1)
            {
                currentProduct = currentProduct.Where(p => p.ProductCurrentDiscount >= 0 && p.ProductCurrentDiscount < 10).ToList();
            }

            if (FilterProduct.SelectedIndex == 2)
            {
                currentProduct = currentProduct.Where(p => p.ProductCurrentDiscount >= 10 && p.ProductCurrentDiscount < 15).ToList();
            }

            if (FilterProduct.SelectedIndex == 3)
            {
                currentProduct = currentProduct.Where(p => p.ProductCurrentDiscount >= 15 && p.ProductCurrentDiscount <= 100).ToList();
            }

            if (SortProduct.SelectedIndex == 0) { }
            if (SortProduct.SelectedIndex == 1)
            {
                currentProduct = currentProduct.OrderBy(p => p.ProductCost).ToList();
            }
            if (SortProduct.SelectedIndex == 2)
            {
                currentProduct = currentProduct.OrderByDescending(p => p.ProductCost).ToList();
            }
            currentProduct = currentProduct.Where(p => p.ProductName.ToLower().Contains(SearchProduct.Text.ToLower())).ToList();
            ProductListView.ItemsSource = currentProduct;

            QuantityAmount.Text = VetoshkinUkrashenieEntities.GetContext().Product.ToList().Count().ToString();
            CurrentQuantity.Text = currentProduct.Count.ToString();
        }

        private void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void SortProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void FilterProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();    
        }
    }
}
