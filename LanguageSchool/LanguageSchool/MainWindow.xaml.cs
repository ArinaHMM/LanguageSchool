using LanguageSchool.Components;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var path = @"C:\Users\222103\Desktop\Demo\Сессия 1\";
            //foreach (var item in App.db.Service.ToArray()) 
            //{
            //    var FullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(FullPath);
            //    item.MainImage = imageByte;
            //}
            //App.db.SaveChanges();
            
            Navigation.mainWindow = this;
            Navigation.NextPage(new PageComponent(new Pages.ServiceListPage(), "ServicePage"));
           // MainFrame.Navigate(new Pages.ServiceListPage());
        }

        private void OnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PAsswordPb.Password == "1234")
            {
                App.isAdmin = true;
                Navigation.ClearHistory();
                MessageBox.Show("Успешно, вы в режиме админа!");
                Navigation.NextPage(new PageComponent(new Pages.ServiceListPage(), "ServicePage"));

                PAsswordPb.Password = "";
               

            }
            
            else if (string.IsNullOrWhiteSpace(PAsswordPb.Password))
                {
                MessageBox.Show("Введите пароль");

            }
            else if (PAsswordPb.Password !="1234")
            {
                MessageBox.Show("Вы не админ!");
            }

        }

        private void OffBtn_Click(object sender, RoutedEventArgs e)
            
        {
            App.isAdmin = false;
            Navigation.ClearHistory();
            MessageBox.Show("Отключение");
           
            Navigation.NextPage(new PageComponent(new Pages.ServiceListPage(), "ServicePage"));
            
            PAsswordPb.Password = "";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
