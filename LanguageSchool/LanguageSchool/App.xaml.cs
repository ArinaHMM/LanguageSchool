﻿using LanguageSchool.Components;
using LanguageSchool.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LanguageSchool1Entities db = new LanguageSchool1Entities();
        public static bool isAdmin = false;
        public static AddEditServicePage servicePage;
    }
}
