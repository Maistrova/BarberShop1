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
    public partial class PersonalPage
    {
        public PersonalPage()
        {
            InitializeComponent();
            Connect.datebase = new BarberShopEntities();
            JobTitleNewCB.ItemsSource = Connect.datebase.PostTable.ToList();
            GenderNewCB.ItemsSource = Connect.datebase.PaulTable.ToList();
            LBPersonal.ItemsSource = Connect.datebase.EmployeeTable.ToList();

        }

        private void GetClear()
        {
            SurnameNewTB.Text = "";
            NameNewTB.Text = "";
            PatronymicNewTB.Text = "";
            JobTitleNewCB.Text = "";
            GenderNewCB.Text = "";
            LoginNewTB.Text = "";
            PasswordNewTB.Text = "";
        }


        private void AddBt2_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameNewTB.Text == "" || NameNewTB.Text == "" || PatronymicNewTB.Text == "" || JobTitleNewCB.Text == "" || GenderNewCB.Text == "" || LoginNewTB.Text == "" || PasswordNewTB.Text == "")
            {
                MessageBox.Show("Пустые поля");
            }
            else
            {
                EmployeeTable employeeTable = new EmployeeTable
                {
                    SurnameEmployee = SurnameNewTB.Text,
                    NameEmployee = NameNewTB.Text,
                    PatronymicEmployee = PatronymicNewTB.Text,
                    PNPostEmployee = (JobTitleNewCB.SelectedItem as PostTable).PersonalNumberPost,
                    PNPaulEmployee = (GenderNewCB.SelectedItem as PaulTable).PersonalNumberPaul,
                    LoginEmployee = LoginNewTB.Text,
                    PasswordEmployee = PasswordNewTB.Text

                };
                try
                {
                    Connect.datebase.EmployeeTable.Add(employeeTable);
                    Connect.datebase.SaveChanges();
                    MessageBox.Show("Сотрудник добавлен");
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
            var Searth = Connect.datebase.EmployeeTable.ToList();

                GetSearch();
            Searth = Searth.Where(Cola =>
            Cola.SurnameEmployee.ToLower().Contains(PoiskTB.Text.ToLower())).ToList();

            LBPersonal.ItemsSource = Searth.OrderBy(Cola => Cola.PersonalNumberEmployee).ToList();
        }

        private void PoiskTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PoiskTB.Text.Length == 0)
            {
                LBPersonal.ItemsSource = Connect.datebase.EmployeeTable.ToList();
            }
            else
            {
            }
        }

        private void DeleteBt2_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данного сотрудника?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Выводим сообщение, и если пользователь нажал кнопку "Да" то; 
            {
                var DaliteEmployee = LBPersonal.SelectedItem as EmployeeTable; // В переменную "DaliteWorker" получаем данные из таблицы "WorkerTable" по сотруднику выбронному в элементе "ListWorkwrListBox"; 

                Connect.datebase.EmployeeTable.Remove(DaliteEmployee); // Удаляем сотрудника из таблицы "DaliteWorker"; 
                Connect.datebase.SaveChanges(); // Сохраняем БД; 
                LBPersonal.ItemsSource = Connect.datebase.EmployeeTable.ToList(); // Выводим в элемент "ListWorkwrListBox" данные из таблицы "WorkerTable"; 
            }
        }

    }
}
