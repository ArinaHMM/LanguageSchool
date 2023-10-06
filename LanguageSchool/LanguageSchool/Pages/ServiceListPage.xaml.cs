using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LanguageSchool.Components;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            var services = App.db.Service.ToList();
            foreach (var service in services)
            {
                ServiceWrapPnl.Children.Add(new ServicesUserControl(service.MainImage, service.Title, service.Cost, service.CostTime, service.Discount.ToString(), service.CostVisibility) );
            }
        }
    }
}
