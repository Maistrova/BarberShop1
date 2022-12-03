using BarberShop1.ClassFrame;
using BarberShop1.Page;
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
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            FrameClass.BodyFrame = MainFrame;
        }

        private void ClientsBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page.ClientPage());
        }

        private void PersonalBt_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new PersonalPage());
        }

        private void ServicesBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page.ServicePage());
        }
    }
}
