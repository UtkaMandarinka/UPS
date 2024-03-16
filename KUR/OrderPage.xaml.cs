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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        BDEntities db; //Инициализация Бд

        public OrderPage()
        {
            InitializeComponent();

            db = new BDEntities(); // Присвоение бд переменную

            OrderGrid.ItemsSource = db.OrderTable.ToList(); //Вывод информации из Бд
        }

        private void OrderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OrderTextBox.Text.Length > 0) //Поиск по Ид 
            {
                try
                {
                    int where = int.Parse(OrderTextBox.Text); //Преобразование текста и число

                    OrderGrid.ItemsSource = db.OrderTable.ToList().Where(x => x.id_order == where); //Проверка
                }
                catch
                {

                    OrderTextBox.Text = null; 
                }
            }
            else
            {
                OrderGrid.ItemsSource = db.ProductTable.ToList(); //Вывод информации из Бд
            }
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AllOrder((sender as Button).DataContext as OrderTable)); //Навигация на форму Редактирования
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllOrder(null)); //Навигация на форму Добавления
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) //Кнопка удаления
        {
            var orderForRemoving = OrderGrid.SelectedItems.Cast<OrderTable>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {orderForRemoving.Count()} элементы?","Внимание", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes) //Проверка на случайное удаление
            {
                try
                {
                    db.OrderTable.RemoveRange(orderForRemoving); //Удаление
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены"); //Сообщение об удаление
                    OrderGrid.ItemsSource = db.OrderTable.ToList();
                }
                catch (Exception ex) 
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            
            
            }
        }
    }
}
