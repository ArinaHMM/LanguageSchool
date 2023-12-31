﻿using LanguageSchool.Components;
using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            App.servicePage = this;
            service = _service;
            this.DataContext = service;

            RefreshPhoto();
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)

        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog() != null)
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
            if (service.DurationInSeconds > 14400)
            {
                MessageBox.Show("Длительность не может превышать 4-х часов!");
            }

        }

        private void SaveImageBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (App.db.Service.Any(x => x.Title == service.Title))
            {
                errors.AppendLine("Такая услуга уже существует!");
            }
            else
            {
                App.db.Service.Add(service);
            }
            if (service.DurationInSeconds > 14400)
            {
                errors.AppendLine("Длительность не может превышать 4-х часов!");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                Navigation.NextPage(new PageComponent(new Pages.ServiceListPage(), "Список услуг"));
            }

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)

                });
                App.db.SaveChanges();

            }
            RefreshPhoto();
        }
        public void RefreshPhoto()
        {
            PhoroWp.Children.Clear();
            foreach (var photo in service.ServicePhoto)
            {
                PhoroWp.Children.Add(new UserControlListView(photo));
            }
            BitmapImage biImg = new BitmapImage();
           
                if (service != null)
                {
                    MemoryStream ms = new MemoryStream(service.MainImage);
                    biImg.BeginInit();
                    biImg.StreamSource = ms;
                    biImg.EndInit();
                    MainImage.Source = biImg;
                }
            }
            

            
        private void LoadedPage()
        {
            RefreshPhoto();
        }


    }
}

     

        //PhoroWp.Children.Clear();
        //        foreach (var photo in service.ServicePhoto)
        //        {
        //            PhoroWp.Children.Add(new UserControlListView(photo));
        //        }











