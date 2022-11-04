using LanguageSchoolClassLibrary;
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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;


namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        ReqForm wds;
        public VerificationWindow()
        {
            InitializeComponent();
        }

        private void СhosenTextLoader(object sender, RoutedEventArgs e)
        {
            //Для сериализации:
            //List<CourseApplication> appSerialization = new List<CourseApplication>();
            //CourseApplication app = new CourseApplication("Basalaeva", "French", 0, 1, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Mironova", "German", 0, 2, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Korolev", "Chinese", 0, 1, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Ivanov", "French", 2, 0, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Petrov", "Chinese", 1, 0, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Sidorov", "French", 2, 1, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Morozov", "German", 1, 2, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Laptev", "Chinese", 1, 1, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Popov", "English", 2, 2, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Popov", "Chinese", 0, 0, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Volkov", "English", 1, 2, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Popov", "German", 0, 1, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Smirnov", "English", 2, 1, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Kotov", "French", 2, 0, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Koshkin", "English", 1, 1, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Egorov", "Chinese", 2, 2, 0);
            //appSerialization.Add(app);
            //app = new CourseApplication("Pavlov", "English", 0, 2, 2);
            //appSerialization.Add(app);
            //app = new CourseApplication("Kozlov", "English", 0, 1, 1);
            //appSerialization.Add(app);
            //app = new CourseApplication("Orlov", "French", 1, 1, 1);
            //appSerialization.Add(app);
            //XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CourseApplication>));
            //using (Stream fStream = new FileStream("Students.xml",
            //  FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    xmlFormat.Serialize(fStream, appSerialization);
            //}
            //MessageBox.Show("Saved animal in XML format!");


            ////Десериализация:
            List<CourseApplication> application = new List<CourseApplication>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<CourseApplication>));
            using (FileStream fs = new FileStream("inputReq.xml", FileMode.OpenOrCreate))
            {
                List<CourseApplication> deserilizeAn = (List<CourseApplication>)formatter.Deserialize(fs);
                if (deserilizeAn != null)
                {
                    foreach (CourseApplication app in deserilizeAn)
                    {
                        Group grup = new Group(0, app.Language, app.Level, app.Intensity);
                        application.Add(app);
                    }
                }
            }
            //Добавление новых людей из файла 
            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                List<CourseApplication> deserilizeAn = (List<CourseApplication>)formatter.Deserialize(fs);
                if (deserilizeAn != null)
                {
                    foreach (CourseApplication app in deserilizeAn)
                    {
                        application.Add(app);
                    }
                }
            }
            //foreach (CourseApplication ap in application)
            //{
            //    MessageBox.Show(ap.Language + ap.Level + ap.Intensity);
            //}
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CourseApplication>));
            using (Stream fStream = new FileStream("Students.xml",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, application);
            }
            //MessageBox.Show("Saved animal in XML format!");
            Close();
            var wds = new MainWindow();
            wds.ShowDialog();
        }
        private void СhosenMakeNewOne(object sender, RoutedEventArgs e)
        {
            wds = new ReqForm();
            wds.Owner = this;
            wds.Show();
            this.Hide();
        }
    }
}
