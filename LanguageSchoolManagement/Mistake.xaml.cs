﻿using System;
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

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для Mistake.xaml
    /// </summary>
    public partial class Mistake : Window
    {
        public Mistake()
        {
            InitializeComponent();
        }
        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}