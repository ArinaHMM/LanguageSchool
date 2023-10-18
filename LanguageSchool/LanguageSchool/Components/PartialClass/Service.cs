using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LanguageSchool.Components
{
    public partial class Service
    {
        public decimal TotalCost
        {
            get
            {
                if (Discount != null)
                    return Cost - (Cost * (decimal)Discount / 100);
                else
                    return Cost;
            }
        }

        public string CostTime
        {



            get
            {
                if (Discount == null)
                    return $"{Cost:0} рублей за {DurationInSeconds / 60} минут";
                else
                    return $"{Cost - (Cost * (decimal)Discount / 100)} рублей за {DurationInSeconds / 60} минут ";

            }

        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string Discounts
        {
            get
            {
                if (Discount == null)
                {
                    return "-";
                }
                else
                    return $"Скидка {Discount}%";
            }
        }
        public Brush DiscountBrush
        {
            get
            {
                if (Discount is null)
                {
                    return new SolidColorBrush(Colors.White);
                }
                else
                {
                    
                    return new SolidColorBrush(Colors.LightGreen);
                }
            }
        }
    }
}
   

        

    



