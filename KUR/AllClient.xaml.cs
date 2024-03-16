using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AllClient.xaml
    /// </summary>
    public partial class AllClient : Page
    {

        private ClientTable _currentClient = new ClientTable();

        BDEntities db;


        public AllClient(ClientTable selectedClient)
        {
            InitializeComponent();
            db = new BDEntities();

            if (selectedClient != null)
            _currentClient = selectedClient;
            DataContext = _currentClient;
            

           
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentClient.name_client))
                errors.AppendLine("Укажите имя");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            db.ClientTable.Add(_currentClient);
            db.SaveChanges();
     
            try 
            
            { 
                MessageBox.Show("Данные сохранены");
            }

            catch (Exception ex) 
            {
               MessageBox.Show(ex.Message.ToString());            
            }


        }
    }
}
