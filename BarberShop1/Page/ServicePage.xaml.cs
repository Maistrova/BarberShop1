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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage 
    {
        public ServicePage()
        {
            InitializeComponent();
            Connect.datebase = new BarberShopEntities();
            LBService.ItemsSource = Connect.datebase.HaircutTable.ToList();
        }

        private void GetClear()
        {
            NameServiceNewTB.Text = "";
            PriceServiceNewTB.Text = "";
        }

        private void AddBt3_Click(object sender, RoutedEventArgs e)
        {
            if (NameServiceNewTB.Text == "" || PriceServiceNewTB.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            else
            {
                int GetPrise = Convert.ToInt32(PriceServiceNewTB.Text);
                HaircutTable haircutTable = new HaircutTable
                {
                    NameHaircut = NameServiceNewTB.Text,
                    PriceHaircut = GetPrise
                };
                try
                {
                    Connect.datebase.HaircutTable.Add(haircutTable);
                    Connect.datebase.SaveChanges();
                    MessageBox.Show("Услуга добавлена");
                    GetClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }     

        private void GetSearch()
        {
            var Searth = Connect.datebase.HaircutTable.ToList();

            Searth = Searth.Where(Cola =>
            Cola.NameHaircut.ToLower().Contains(PoiskTB.Text.ToLower())).ToList();

            LBService.ItemsSource = Searth.OrderBy(Cola => Cola.PersonalNumberHaircut).ToList();
        }

        private void PoiskTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PoiskTB.Text.Length == 0)
            {
                LBService.ItemsSource = Connect.datebase.HaircutTable.ToList();
            }
            else
            {
                GetSearch();
            }
        }

        private void DeleteBt3_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данного сотрудника?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Выводим сообщение, и если пользователь нажал кнопку "Да" то; 
            {
                var DaliteEmployee = LBService.SelectedItem as EmployeeTable; // В переменную "DaliteWorker" получаем данные из таблицы "WorkerTable" по сотруднику выбронному в элементе "ListWorkwrListBox"; 

                Connect.datebase.EmployeeTable.Remove(DaliteEmployee); // Удаляем сотрудника из таблицы "DaliteWorker"; 
                Connect.datebase.SaveChanges(); // Сохраняем БД; 
                LBService.ItemsSource = Connect.datebase.EmployeeTable.ToList(); // Выводим в элемент "ListWorkwrListBox" данные из таблицы "WorkerTable"; 
            }
        }
    }
}
