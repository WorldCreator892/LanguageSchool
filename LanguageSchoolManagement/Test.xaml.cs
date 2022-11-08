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

            sch = RandomCourseEventsAndGeneration.GenerateLanguageSchool(
                new List<string>() {
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
                }, new List<string>() {"French", "English" });//40 имен.
            sch.ReformCourses();
            foreach (Course c in sch.Courses)
            {
                this.ListBoxTest.Items.Add("COURSE:" + c.Language + " " + c.StandartPayment + " " + c.StudentAmount + " " + c.Groups.Count);
                foreach (Group g in c.Groups)
                {
                    this.ListBoxTest.Items.Add("GROUP:" + g.ID);
                    this.ListBoxTest.Items.Add(g.Language + " " + g.Level + " " + g.Intensity + " ");
                    foreach (int st in g.StudentIDs)
                    {
                        this.ListBoxTest.Items.Add("STUDENT ID:    " + st);
                    }
                }
            }
            foreach (Student st in sch.Students)
            {
                this.ListBoxTest.Items.Add("STUDENT:" + st.ID + " " + st.Surname);
                foreach(CourseApplication c in st.Applications)
                {
                    this.ListBoxTest.Items.Add("APPLICATION:" + c.GroupID + " " + c.Language + " " + c.Level + " " + c.Status + " " + c.Intensity);
                }
            }
        }
    }
}
