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
using LanguageSchoolClassLibrary;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для ReqForm.xaml
    /// </summary>
    public partial class ReqForm : Window
    {
        List<Group> Groups;//Список всех группп.
        Student student;
        CourseApplication application;
        public ReqForm()
        {
            InitializeComponent();
            Groups = new List<Group>();
            application = new CourseApplication("", "", 0, 0, 0);
        }
        private void TextBox_Surname(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_Name(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonClickInfo(object sender, RoutedEventArgs e)
        {
            if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
               ChoiceLevel.SelectedIndex == -1 || TextSurname.Text==String.Empty || TextName.Text==String.Empty)
            {
                var wds = new Mistake();
                wds.Owner = this;
                wds.ShowDialog();
            }
            else
            {
                var wds = new Adding();
                wds.Owner = this;
                wds.ShowDialog();
                Close();



                //Формируем заявку:
                application.Surname = TextSurname.Text;//Заполняем фамилию.
                string Name = TextName.Text;//Просто так для красоты, но возможно где-то потребуется.
                                            //Заполняем пунтк интенсивность в заявке:
                if (ChoiceIntensity.Text == "Intensive")
                {
                    application.Intensity = 2;
                }
                if (ChoiceIntensity.Text == "Regular")
                {
                    application.Intensity = 1;
                }
                if (ChoiceIntensity.Text == "Supportive")
                {
                    application.Intensity = 0;
                }
                //Заполняем пунтк уровень в заявке:
                if (ChoiceLevel.Text == "Advanced")
                {
                    application.Level = 2;
                }
                if (ChoiceLevel.Text == "Intermediate")
                {
                    application.Level = 1;
                }
                if (ChoiceLevel.Text == "Elementary")
                {
                    application.Level = 0;
                }
                //Заполняем пунтк язык в заявке:
                application.Language = ChoiceLanguage.Text;
                //MessageBox.Show(application.Surname);
                //MessageBox.Show(application.Language);
                //MessageBox.Show(application.Intensity.ToString());
                //MessageBox.Show(application.Level.ToString());
                Group grup = new Group(0, application.Language, application.Level, application.Intensity);
            }
        }

        private void ChoiceLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Owner.Show();
            
        }
    }
}
