using LanguageSchoolClassLibrary;
using Microsoft.Office.Interop.Excel;
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
        }
        private void ButtonRulesClick(object sender, RoutedEventArgs e)
        {
            var wds = new Menu();
            wds.Owner = this;
            wds.ShowDialog();

        }
        private void ButtonClickInfo(object sender, RoutedEventArgs e)
        {
            //if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
            //   ChoiceLevel.SelectedIndex == -1 || ChoiceType.SelectedIndex == -1)
            //{
               
            //    var wds = new Mistake();
            //    wds.Owner = this;
            //    wds.ShowDialog();
            //}
            //else
            {
                var wds = new Result();
                wds.Owner = this;
                wds.ShowDialog();
               
            }
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
                ChoiceLevel.SelectedIndex == -1 || ChoiceType.SelectedIndex == -1 || ChoiceTime.SelectedIndex == -1)
            {
                var wds = new Mistake();
                wds.Owner = this;
                wds.ShowDialog();
            }
            else
            {
                var wds = new VerificationWindow();
                wds.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                this.Hide();
                wds.Owner = this;
                wds.ShowDialog();

            }
            CourseApplication application = new CourseApplication();
            ////Формируем заявку:
            ////Заполняем пунтк интенсивность в заявке:
            //if (ChoiceIntensity.Text == "Intensive")
            //{
            //    application.Intensity = 2;
            //}
            //if (ChoiceIntensity.Text == "Regular")
            //{
            //    application.Intensity = 1;
            //}
            //if (ChoiceIntensity.Text == "Supportive")
            //{
            //    application.Intensity = 0;
            //}
            ////Заполняем пунтк уровень в заявке:
            //if (ChoiceLevel.Text == "Advanced")
            //{
            //    application.Level = 2;
            //}
            //if (ChoiceLevel.Text == "Intermediate")
            //{
            //    application.Level = 1;
            //}
            //if (ChoiceLevel.Text == "Elementary")
            //{
            //    application.Level = 0;
            //}
            //////Заполняем пунтк язык в заявке:
            //application.Language = ChoiceLanguage.Text;
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //Worksheet ws = wb.Worksheets[1];
            //DateTime currentDate = DateTime.Now;

            //List<CourseApplication> App = new List<CourseApplication>();
            //XmlSerializer formatter = new XmlSerializer(typeof(List<CourseApplication>));
            //using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            //{
            //    List<CourseApplication> deserilizeAn = (List<CourseApplication>)formatter.Deserialize(fs);

            //    if (deserilizeAn != null)
            //    {
            //        foreach (CourseApplication app1 in deserilizeAn)
            //        {
            //            Group grup = new Group(0, app1.Language, app1.Level, app1.Intensity);
            //            App.Add(app1);
            //        }
            //    }
            //}
            //ws.Range["A1"].Value = "Surname";
            //ws.Range["B1"].Value = "Language";
            //ws.Range["C1"].Value = "Level";
            //ws.Range["D1"].Value = "Intensity";
            //int counter = 2;
            //foreach (CourseApplication person in App)
            //{
            //    if (person.Language == application.Language && person.Intensity == application.Intensity
            //        && person.Level == application.Level)
            //    {
            //        ws.Range["A" + counter].Value = person.Surname;
            //        ws.Range["B" + counter].Value = person.Language;
            //        ws.Range["C" + counter].Value = person.Level;
            //        ws.Range["D" + counter].Value = person.Intensity;
            //        counter++;
            //    }
            //}
            //wb.SaveAs("C:\\Users\\admin\\Desktop\\LanguageSchool-newMain\\ChoiceGroup.xlsx");
            //Close();

        }

       
    }
}
