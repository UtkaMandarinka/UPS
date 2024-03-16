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
using KUR.Model;


namespace KUR
{
    /// <summary>
    /// Логика взаимодействия для ProductAll.xaml
    /// </summary>
    public partial class ProductAll : Page
    {

        private ProductTable _currentProduct = new ProductTable();

        BDEntities db;

        public ProductAll(ProductTable selectedProduct)
        {

            if (selectedProduct != null)
                _currentProduct = selectedProduct;


            db = new BDEntities();

            DataContext = _currentProduct;

            InitializeComponent();

            CBoxStOp.ItemsSource = db.TypeProductTable.ToList();
            KodKlTx.ItemsSource = db.WarehouseTable.ToList();
            CS.ItemsSource = db.SupplierTable.ToList();


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
   

            db.ProductTable.Add(_currentProduct);
            db.SaveChanges();
            MessageBox.Show("Данные сохранены");
        }
    }
}
