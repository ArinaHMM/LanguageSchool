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

namespace LanguageSchool.Components
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class ServicesUserControl : UserControl
    {
        public ServicesUserControl(byte[] image, string Title, decimal cost, String CostTime, Visibility costVisibility, String Discounts)
        {
            InitializeComponent();
            if (App.isAdmin == false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
            BitmapImage imgSrc = new BitmapImage();
            MemoryStream ms = new MemoryStream(image);
            imgSrc.BeginInit();
            imgSrc.StreamSource = ms;
            imgSrc.EndInit();
            ImageSource imgsrc = imgSrc as ImageSource;
            
            //ServiceImg.Source = "C:\\Users\\222103\\source\\repos\\LanguageSchool\\LanguageSchool\\LanguageSchool\\Source\\school_logo.png"
            TitleTb.Text = Title;
            CostTb.Text = CostTime.ToString();
            ServiceImg.Source = imgSrc;
            //DiscountTB.Text = Discount;
            JustCost.Text = cost.ToString();
            CostTb.Visibility = costVisibility;
            DiscountsTb.Text = Discounts.ToString();
            

        }
    }
}
