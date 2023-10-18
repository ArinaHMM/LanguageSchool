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
using System.ComponentModel;

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
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                Refresh();
            }
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Service> services = App.db.Service.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }



            ServiceWrapPnl.Children.Clear();
            foreach (var service in services)
            {
                ServiceWrapPnl.Children.Add(new ServicesUserControl(service));
            }

            if (DiscountFilterCb.SelectedIndex !=0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                {
                    services = services.Where(x => x.Discount == null || x.Discount < 5);
                }
                else if (DiscountFilterCb.SelectedIndex == 2)
                {
                    services = services.Where(x => x.Discount == 5 || x.Discount < 15);
                }
                else if (DiscountFilterCb.SelectedIndex == 3)
                {
                    services = services.Where(x => x.Discount == 15 || x.Discount < 30);
                }
                else if (DiscountFilterCb.SelectedIndex == 4)
                {
                    services = services.Where(x => x.Discount == 31 || x.Discount < 70);
                }
                else if (DiscountFilterCb.SelectedIndex == 5)
                {
                    services = services.Where(x => x.Discount == 71 || x.Discount < 100);

                }
            }
            if(SearchTb.Text != null)
            {
                services = services.Where(x => x.Title.ToLower().Contains
                (SearchTb.Text.ToLower()) || x.Description.ToLower().Contains
                (SearchTb.Text.ToLower()));
            }

            CountOfItems.Text = $"{services.Count()} из {App.db.Service.Count()}";


        }
        

                private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    Refresh();
                }

                private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
                {
                    Refresh();
                }

                private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    Refresh();
                }
            } } 
   
    

