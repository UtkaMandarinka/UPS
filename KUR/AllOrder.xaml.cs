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
    /// Логика взаимодействия для AllOrder.xaml
    /// </summary>
    public partial class AllOrder : Page
    {
        private OrderTable _currentOrder = new OrderTable(); //Cоздание переменной

        BDEntities db;

        public AllOrder(OrderTable selectedOrder)
        {
            InitializeComponent();

            if (selectedOrder != null)  
                _currentOrder = selectedOrder; 

            db = new BDEntities(); //Переменная для бд

            DataContext = _currentOrder;


            CBoxPv.ItemsSource = db.PointTable.ToList(); //Лист для комбобокса
            CBoxStTo.ItemsSource = db.ProductStatusTable.ToList(); //Лист для комбобокса
            CBoxStOp.ItemsSource = db.ProductPaymentStatusTable.ToList(); //Лист для комбобокса

        }

        private void CBoxStOp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
  

            db.OrderTable.Add(_currentOrder); //Запись в таблицу
            db.SaveChanges(); //Созранение записи в таблице
            MessageBox.Show("Данные сохранены");
        }

        private void KodTvTx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
