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

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для UserControlListView.xaml
    /// </summary>
    public partial class UserControlListView : UserControl
    {
        ServicePhoto service;
        public UserControlListView(ServicePhoto _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            
        }

        private void MainBnt_Click(object sender, RoutedEventArgs e)
        {
            // var serviceId = service.ServiceID;
            var selPhoto = service.PhotoByte;
            service.PhotoByte = service.Service.MainImage;
            service.Service.MainImage = selPhoto;
            App.servicePage.RefreshPhoto();
            App.db.SaveChanges();

        }

        private void DeletePhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            //var selPhoto = sender as ServicePhoto;
            App.db.ServicePhoto.Remove(service);
            App.servicePage.RefreshPhoto();
            App.db.SaveChanges(); 

        }

    }
}
