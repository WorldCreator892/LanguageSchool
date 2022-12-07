using LanguageSchoolClassLibrary;
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
        public int GenerationLength = 3;
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
            // Info f = new Info(l);
            //f.ShowDialog();
            var wds = new SettingsWindow();
            GenerationLength = wds.SliderValue;
            wds.Close();
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
            var wds = new Info(languageSchool, GenerationLength);
            wds.Owner = this;
            wds.ShowDialog();
            
        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            var wds = new SettingsWindow();
            wds.Owner = this;
            wds.ShowDialog();
        }
    }
}
