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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : System.Windows.Window
    {
        public Result()
        {
            InitializeComponent();
            
        }
        private void GenerateExcelTable(object sender, RoutedEventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            DateTime currentDate = DateTime.Now;

            List<CourseApplication> application = new List<CourseApplication>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<CourseApplication>));
            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                List<CourseApplication> deserilizeAn = (List<CourseApplication>)formatter.Deserialize(fs);

                if (deserilizeAn != null)
                {
                    foreach (CourseApplication app1 in deserilizeAn)
                    {
                        Group grup = new Group(0, app1.Language, app1.Level, app1.Intensity);
                        application.Add(app1);
                    }
                }
            }

            ws.Range["A1"].Value = "Surname";
            ws.Range["B1"].Value = "Language";
            ws.Range["C1"].Value = "Level";
            ws.Range["D1"].Value = "Intensity";
            for (int i = 2; i <= application.Count + 1; i++)
            {
                ws.Range["A" + i].Value = application[i - 2].Surname;
                ws.Range["B" + i].Value = application[i - 2].Language;
                ws.Range["C" + i].Value = application[i - 2].Level;
                ws.Range["D" + i].Value = application[i - 2].Intensity;
            }
            wb.SaveAs("C:\\Users\\admin\\Desktop\\LanguageSchool-newMain\\LanguageSchool.xlsx");

            Close();


        }
    }
}
