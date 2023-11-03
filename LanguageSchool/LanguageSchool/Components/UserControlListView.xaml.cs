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
        ServicePhoto servicePhoto;
        public UserControlListView(ServicePhoto _servicePhoto)
        {
            InitializeComponent();
            servicePhoto = _servicePhoto;
            this.DataContext = servicePhoto;
        }

        private void MainBnt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePhotoBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
