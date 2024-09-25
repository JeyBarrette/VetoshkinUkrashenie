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
        }

        private void UpdateProduct()
        {
            var currentProduct = VetoshkinUkrashenieEntities.GetContext().Product.ToList();

            currentProduct = currentProduct.Where(p => (p.ProductName.ToLower().Contains(SearchProduct.Text.ToLower());
            if (SortProduct.SelectedIndex == 0)
            {

            }
            if (SortProduct.SelectedIndex == 1)
            {
                currentProduct = currentProduct.OrderBy(p => p.ProductName).ToList();
            }
            if (SortProduct.SelectedIndex == 2)
            {
                currentProduct = currentProduct.OrderByDescending(p => p.ProductName).ToList();
            }
        }

        private void SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SortProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
