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
            List<CourseApplication> application = new List<CourseApplication>();
            StreamReader f = new StreamReader("inputReq.txt");
            while (!f.EndOfStream)
            {
                CourseApplication app = new CourseApplication("", "", 0, 0, 0);
                string[] s = new string[5];
                s = f.ReadLine().Split(' ');
                //MessageBox.Show(s[0] + s[1] + s[2] + s[3] + s[4]);
                app.Language = s[2];
                app.Intensity = int.Parse(s[3]);
                app.Level = int.Parse(s[4]);
                app.Surname = s[1];
                Group grup = new Group(0, app.Language, app.Level, app.Intensity);
                application.Add(app);
            }
            //foreach (CourseApplication c in application)
            //{
            //    MessageBox.Show(c.Language + c.Level + c.Intensity);
            //}
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
