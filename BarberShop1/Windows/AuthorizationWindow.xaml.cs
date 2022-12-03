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
using System.Windows.Shapes;

namespace BarberShop1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            Connect.datebase = new BarberShopEntities();
        }

        private void OpenWindow() // Метод для открытия окна
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            //MenuWindow menuWindow = new MenuWindow();
            //menuWindow.Show();
            //this.Close();

            if (LoginTextBox.Text == "" &&
                PasswordPasswordBox.Password == "" ||
                LoginTextBox.Text == null &&
                PasswordPasswordBox.Password == null) // проверка полей на пустоту
            {
                MessageBox.Show(
                    "Поле Логин или поле Пароль пустое",
                    "Пустота",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    var user = Connect.datebase.EmployeeTable.FirstOrDefault(
                        data => data.LoginEmployee == LoginTextBox.Text &&
                                data.PasswordEmployee == PasswordPasswordBox.Password); // Получение данных для работы
                    if (user == null) // Если пользователя нет в БД
                    {
                        MessageBox.Show(
                            "Неправельный Логин или Пароль",
                            "Ошибка авторизации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }

                    else
                    {
                        switch (user.PNPostEmployee)
                        {
                            case 1: // Если "Роль = 1" 
                                OpenWindow(); // Метод для открытия окна
                                break;
                            case 2: // Если "Роль = 2" 
                                OpenWindow(); // Метод для открытия окна
                                break;
                            case 3: // Если "Роль = 3" 
                                OpenWindow(); // Метод для открытия окна
                                break;
                            case 4: // Если "Роль = 4" 
                                OpenWindow(); // Метод для открытия окна
                                break;

                            default: // Всем остальным говорим, что нельзя
                                MessageBox.Show(
                                    "Отказано в доступе",
                                    "Ошибка доступа",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                                break;
                        }
                    }
                }
                catch (Exception ex) // Метод, который проверяет на наличае ошибок в приложении с которыми пользователь может сталкнуться при входе
                {
                    MessageBox.Show(
                        ex + "",
                        "Ошибка Exception",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
}
