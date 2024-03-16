using KUR.Model;
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


namespace KUR
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        BDEntities db;

        public ProductPage()
        {
            InitializeComponent();
            db = new BDEntities();

            ProductGrid.ItemsSource = db.ProductTable.ToList();
        }

        private void ProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProductTextBox.Text.Length > 0)
            {
                try
                {
                    int where = int.Parse(ProductTextBox.Text);

                    ProductGrid.ItemsSource = db.ProductTable.ToList().Where(x => x.id_product == where);
                }
                catch
                {

                    ProductTextBox.Text = null;
                }
            }
            else
            {
                ProductGrid.ItemsSource = db.ProductTable.ToList();
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductAll(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = ProductGrid.SelectedItems.Cast<ProductTable>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {productForRemoving.Count()} элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    db.ProductTable.RemoveRange(productForRemoving);
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ProductGrid.ItemsSource = db.ProductTable.ToList();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductAll((sender as Button).DataContext as ProductTable));
        }
    }
}
