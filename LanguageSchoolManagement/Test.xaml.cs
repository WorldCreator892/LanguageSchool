using System;
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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        LanguageSchool sch;
        public Test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sch = RandomCourseEventsAndGeneration.GenerateLanguageSchool(new List<string>() { "Ваня", "Петя", "Саня" });
            sch.ReformCourses(RandomCourseEventsAndGeneration.GenerateApplications(sch));
            foreach(Course c in sch.Courses)
            {
                foreach(Group g in c.Groups)
                {
                    this.ListBoxTest.Items.Add(g.Language + " " + g.Level + " " + g.Intensity + " ");
                    foreach(string st in g.StudentNames)
                    {
                        this.ListBoxTest.Items.Add(st);
                    }
                }
            }
        }
    }
}
