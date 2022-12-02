﻿using LanguageSchoolClassLibrary;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Serialization;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += Window_Closing;

            LanguageSchool l = RandomCourseEventsAndGeneration.GenerateLanguageSchool(new List<string>() {
                "Иван",
                "Владимир",
                "Александр",
                "Светлана",
                "Екатерина",
                "Алексей",
                "Мария",
                "Михаил",
                //"Сергей",
                //"Никита",
                //"Алена",
                //"Артем",
                //"Елена",
                //"Софья",
                //"Олег",
                //"Анастасия",
                //"Виктория",
                //"Констатин",
                //"Карина",
                //"Кристина",
                //"Валентина",
                //"Альбина",
                //"Нина",
                //"Милана",
                //"Варвара",
                //"Анатолий",
                "Петр",
                "Федор",
                "Ангелина",
                "Артемий",
                "Глеб",
                "Тимофей",
                "Николай",
                "Лириса",
                "Елизавета",
                "Надежда",
                "Людмила",
                "Илья",
                "Борис",
                "Юлия"
                }, new List<string>() { "French", "English" });
            l.ReformCourses();
            Info f = new Info(l);
            f.ShowDialog();
        }
        static void Window_Closing(object sender, CancelEventArgs e)
        {

        if(MessageBox.Show( "Are you sure?", "Exit",
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
               
            }
            else e.Cancel = true;
            

        }
        private void ButtonRulesClick(object sender, RoutedEventArgs e)
        {
            var wds = new Menu();
            wds.Owner = this;
            wds.ShowDialog();

        }
        private void ButtonClickGenerate(object sender, RoutedEventArgs e)
        {
            List<string> PossibleSurnames = new List<string>() { "Петров", "Иванов", "Попов", "Ильин",
                    "Федоров","Белов","Серов","Игнатов","Чернов","Свиридов","Яров","Шишкин","Котов",};
            List<string> PossibleLanguages = new List<string>() { "English", "French", "German", "Chinese" };
            //Если 1 языковая школа:
            LanguageSchool languageSchool = RandomCourseEventsAndGeneration.GenerateLanguageSchool(PossibleSurnames, PossibleLanguages);
            languageSchool.ReformCourses();
            var wds = new Info(languageSchool);
            wds.Owner = this;
            wds.ShowDialog();



            //List<string> PossibleSurnames = new List<string>() { "Петров", "Иванов", "Попов", "Ильин",
            //        "Федоров","Белов","Серов","Игнатов","Чернов","Свиридов","Яров","Шишкин","Котов",};
            //List<string> PossibleLanguages = new List<string>() { "English", "French", "German", "Chinese" };
            ////Если 1 языковая школа:
            //LanguageSchool languageSchool = RandomCourseEventsAndGeneration.GenerateLanguageSchool(PossibleSurnames, PossibleLanguages);
            //languageSchool.ReformCourses();
            //string file1 = "C:\\Users\\admin\\Desktop\\LanguageSchool-newMain\\LanguageSchool.xlsx";
            ////Если список языковых школ:
            ////List<LanguageSchool> languageSchools = new List<LanguageSchool>();
            ////for (int i = 0; i < 5; i++)
            ////{
            ////    languageSchool = RandomCourseEventsAndGeneration.GenerateLanguageSchool(PossibleSurnames, PossibleLanguages);
            ////    languageSchool.ReformCourses();
            ////    languageSchools.Add(languageSchool);
            ////}
            ////WorkWithExcel.WriteListLanguageSchoolToExcel(languageSchools, file1);
            //try
            //{
            //    WorkWithExcel.WriteLanguageSchoolToExcel(languageSchool, file1);
            //}
            //catch (System.Runtime.InteropServices.COMException)
            //{
            //    MessageBox.Show("Ошибка при сохранении документа. Текущая версия файла может быть сохранена в уже созданный файл при закрытии таблицы.");
            //}
        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            var wds = new SettingsWindow();
            wds.ShowDialog();
        }
    }
}
