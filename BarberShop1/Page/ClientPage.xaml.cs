using BarberShop1.ClassFrame;
using BarberShop1.Model;
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

namespace BarberShop1.Page
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage 
    {
        public ClientPage()
        {
            InitializeComponent();
            Connect.datebase = new BarberShopEntities();
            LBClients.ItemsSource = Connect.datebase.RecordTable.ToList();
        }

        
        private void GetSearch()
        {
            var Searth = Connect.datebase.RecordTable.ToList();

            Searth = Searth.Where(Cola =>
            Cola.SurnameClient.ToLower().Contains(PoiskTB.Text.ToLower())||
            Cola.NameClient.ToLower().Contains(PoiskTB.Text.ToLower())).ToList();

            LBClients.ItemsSource = Searth.OrderBy(Cola => Cola.PesonalNumberRecord).ToList();
        }
        private void PoiskTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (PoiskTB.Text.Length == 0)
            {
                LBClients.ItemsSource = Connect.datebase.RecordTable.ToList();
            }
            else
            {
                GetSearch();
            }
        }
        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данного клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Выводим сообщение, и если пользователь нажал кнопку "Да" то; 
            {
                var DaliteRecord = LBClients.SelectedItem as RecordTable; // В переменную "DaliteWorker" получаем данные из таблицы "WorkerTable" по сотруднику выбронному в элементе "ListWorkwrListBox"; 

                Connect.datebase.RecordTable.Remove(DaliteRecord); // Удаляем сотрудника из таблицы "DaliteWorker"; 
                Connect.datebase.SaveChanges(); // Сохраняем БД; 
                LBClients.ItemsSource = Connect.datebase.RecordTable.ToList(); // Выводим в элемент "ListWorkwrListBox" данные из таблицы "WorkerTable"; 
            }
        }

    }
}
