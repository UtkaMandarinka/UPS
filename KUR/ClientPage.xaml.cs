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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        BDEntities db;

        public ClientPage()
        {
            InitializeComponent();
            db = new BDEntities();

           

            ClientGrid.ItemsSource = db.ClientTable.ToList();
        }

        private void ClientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (ClientTextBox.Text.Length > 0)
            {
                try
                {
                    string where = (ClientTextBox.Text);

                    ClientGrid.ItemsSource = db.ClientTable.ToList().Where(x => x.surname_client == where);
                }
                catch
                {

                    ClientTextBox.Text = null;
                }
            }
            else
            {
                ClientGrid.ItemsSource = db.ClientTable.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllClient(null));
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllClient((sender as Button).DataContext as ClientTable));
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = ClientGrid.SelectedItems.Cast<ClientTable>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {clientForRemoving.Count()} элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    db.ClientTable.RemoveRange(clientForRemoving);
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ClientGrid.ItemsSource = db.ClientTable.ToList();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) 
            {
                db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ClientGrid.ItemsSource = db.ClientTable.ToList();
            }
        }
    }
}
