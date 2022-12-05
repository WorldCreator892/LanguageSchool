using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using LanguageSchoolClassLibrary;
using Group = LanguageSchoolClassLibrary.Group;

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
        public bool IsNameValid(string name)
        {
            bool valid = false;
            Regex check = new Regex(@"(^[a-zA-Z]+)$");
            valid = check.IsMatch(name);

            if (valid == true)
            {
                return valid;
            }
            else
            {
                return valid;
            }
        }
        private void ProgramClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want close application?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
            else e.Cancel = true;
        }

        private void TextBox_Surname(object sender, TextChangedEventArgs e)
        {
        }
        private void TextBox_Name(object sender, TextChangedEventArgs e)
        {
        }
        private void ButtonClickInfo(object sender, RoutedEventArgs e)
        {
            if ((IsNameValid(TextName.Text)) == false || (IsNameValid(TextSurname.Text) == false))
            {
                MessageBox.Show("Неправильный формат имени или фамилии!");
            }
            else if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
               ChoiceLevel.SelectedIndex == -1 || TextSurname.Text == String.Empty || TextName.Text == String.Empty)
            {
                var wds = new Mistake();
                wds.Owner = this;
                wds.ShowDialog();
            }
            else
            {
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

                Group grup = new Group(0, application.Language, application.Level, application.Intensity);
                //Добавление новых людей в файл 
                List<CourseApplication> StudentList = new List<CourseApplication>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<CourseApplication>));
                using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
                {
                    List<CourseApplication> deserilizeAn = (List<CourseApplication>)formatter.Deserialize(fs);
                    if (deserilizeAn != null)
                    {
                        foreach (CourseApplication app in deserilizeAn)
                        {
                            StudentList.Add(app);
                        }
                    }
                }
                StudentList.Add(application);
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CourseApplication>));
                using (Stream fStream = new FileStream("Students.xml",
                  FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fStream, StudentList);
                }
                var wds = new Result();
                wds.Owner = this;
                wds.ShowDialog();
                wds.Close();
                Close();

            }
        }
        private void ChoiceLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ButtonClickReturnInfo(object sender, RoutedEventArgs e)
        {
            Close();
            var wds = new MainWindow();
            wds.ShowDialog();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Owner.Show();
            
        }
    }
}
