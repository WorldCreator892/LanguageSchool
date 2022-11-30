using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchoolClassLibrary;
using Microsoft.Office.Interop.Excel;

namespace LanguageSchoolClassLibrary
{
    public class WorkWithExcel
    {
<<<<<<< HEAD
        public static void WritingLanguageSchoolToExcel(LanguageSchool languageSchool, Microsoft.Office.Interop.Excel.Worksheet sheet)
        {
            Dictionary<int, string> people = new Dictionary<int, string>();
=======
        public static void WriteLanguageSchoolToExcel(LanguageSchool languageSchool, string saveAs)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Dictionary<int, string> people = new Dictionary<int, string>();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            //var sh = wb.Sheets;
            //Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)sh.Add(Type.Missing, sh[1], Type.Missing, Type.Missing);

            //sheet2.Name = "Студенты и ID";
            //sheet2.Range["A1"].Value = "Surname";
            //sheet2.Range["B1"].Value = "ID";
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
            for (int i = 2; i <= languageSchool.Students.Count + 1; i++)
            {
                Student s = languageSchool.Students[i - 2];
                people[s.ID] = s.Surname;
<<<<<<< HEAD
            }
=======
                //Console.WriteLine(people[s.ID].ToString());
                //sheet2.Range["A" + i].Value = s.Surname;
                //sheet2.Range["B" + i].Value = s.ID;
            }
            sheet.Name = "Courses and Groups";
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
            sheet.Range["A1"].Value = "Language";
            sheet.Range["B1"].Value = "Students Amount";
            sheet.Range["C1"].Value = "Standart Payment ";
            sheet.Range["D1"].Value = "Individual Coefficient";
            sheet.Range["E1"].Value = "Groups";
            sheet.Range["F1"].Value = "Surname";
            sheet.Range["G1"].Value = "ID";
            int cnt = 2;
            for (int i = 0; i < languageSchool.Courses.Count; i++)
            {
                Course c = languageSchool.Courses[i];
                sheet.Range["A" + cnt].Value = c.Language;
                sheet.Range["B" + cnt].Value = c.StudentAmount;
                sheet.Range["C" + cnt].Value = c.StandartPayment;
                sheet.Range["D" + cnt].Value = c.IndividualCoefficient;
                for (int j = 0; j < c.Groups.Count; j++)
                {
                    Group g = c.Groups[j];
<<<<<<< HEAD

                    sheet.Range["E" + cnt].Value = g.ID;

                    for (int e = 0; e < g.StudentIDs.Count; e++)
                    {

=======
                    sheet.Range["E" + cnt].Value = g.ID;
                    for (int e = 0; e < g.Amount; e++)
                    {
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
                        int stdID = g.StudentIDs[e];
                        sheet.Range["G" + cnt].Value = stdID;
                        string s = "";
                        people.TryGetValue(g.StudentIDs[e], out s);
                        sheet.Range["F" + cnt].Value = s;
                        cnt++;
<<<<<<< HEAD
                        if (e == g.StudentIDs.Count - 1)
=======
                        if (e == g.Amount - 1)
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
                            cnt--;
                    }
                    cnt++;
                    if (j == c.Groups.Count - 1)
                        cnt--;
                }
                cnt++;
            }
<<<<<<< HEAD
        }
        public static void WriteListLanguageSchoolToExcel(List<LanguageSchool> languageSchools, string saveAs)//Для записи Листа школ в excel
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Dictionary<int, string> people = new Dictionary<int, string>();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            int index = 1;
            foreach (LanguageSchool languageSchool in languageSchools)
            {
                var newWS = (Worksheet)wb.Sheets.Add(After: wb.ActiveSheet);
                newWS.Name = "Courses and Groups" + index.ToString();
                WritingLanguageSchoolToExcel(languageSchool, newWS);
                index++;
            }
            wb.SaveAs(saveAs);
        }
        public static void WriteLanguageSchoolToExcel(LanguageSchool languageSchool, string saveAs)//Для записи 1 школы в excel
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Dictionary<int, string> people = new Dictionary<int, string>();
            app.SheetsInNewWorkbook = 2;
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            var newWS = (Worksheet)wb.Sheets.Add(After: wb.ActiveSheet);
            newWS.Name = "Courses and Groups";
            WritingLanguageSchoolToExcel(languageSchool, newWS);
            wb.SaveAs(saveAs);
        }
        public static void ReadLanguageSchoolFromExcelToFile(string readFrom)
=======
            wb.SaveAs(saveAs);
        }

        public static void ReadLanguageSchoolFromExcel(LanguageSchool languageSchool, string readFrom)
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
        {
            StreamWriter SW = new StreamWriter(new FileStream("ReadFromExcel.txt", FileMode.Create, FileAccess.Write));
            Application excelApp = new Application();
            Workbook excelBook = excelApp.Workbooks.Open(readFrom);
            Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            Course course = new Course();
            Group group = new Group(0, "", 0, 0);
            Student student = new Student();
            for (int i = 2; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value != null)
                    {
                        if (j == 1)
                        {
                            course.Language = excelRange.Cells[i, j].Text.ToString();

                        }
                        if (j == 2)
                        {
                            course.StudentAmount = int.Parse(excelRange.Cells[i, j].Text.ToString());
                        }
                        if (j == 3)
                        {
                            course.StandartPayment = int.Parse(excelRange.Cells[i, j].Text.ToString());
                        }
                        if (j == 4)
                        {
                            course.IndividualCoefficient = int.Parse(excelRange.Cells[i, j].Text.ToString());
                        }
                        if (j == 5)
                        {
                            group.ID = int.Parse(excelRange.Cells[i, j].Text.ToString());
                        }
                        if (j == 6)
                        {
                            student.Surname = excelRange.Cells[i, j].Text.ToString();
                        }
                        if (j == 7)
                        {
                            student.ID = int.Parse(excelRange.Cells[i, j].Text.ToString());
                            group.StudentIDs.Add(student.ID);
                            course.Groups.Add(group);
                        }
                    }
                    if (excelRange.Cells[i, j] == null || excelRange.Cells[i, j].Value == null)
                    {
                        if (j == 1)
                        {
                            course.Language = " ";
                        }
                        if (j == 5)
                        {
                            group.ID = -1;
                        }
                        if (j == 6)
                        {
                            student.Surname = " ";
                        }
                        if (j == 7)
                        {
                            student.ID = -1;
                        }
                    }
                }
                if (course.Language != " ")
                {
                    if (group.ID != -1)
                    {
                        SW.WriteLine(course.Language + " " + course.StudentAmount + " " + course.StandartPayment + " " + course.IndividualCoefficient
                           + " " + group.ID + " " + student.Surname + " " + student.ID);
                    }
                    else
                    {
<<<<<<< HEAD
                        SW.WriteLine(course.Language + " " + course.StudentAmount + " " + course.StandartPayment + " " + course.IndividualCoefficient
                            + " " + " " + " ");
=======
                        SW.WriteLine(course.Language + " " + course.StudentAmount + " " + course.StandartPayment + " " + course.IndividualCoefficient);
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89
                    }

                }
                if (course.Language == " " && group.ID != -1)
                {
<<<<<<< HEAD
                    SW.WriteLine(" " + " " + " " + " " + group.ID + " " + student.Surname + " " + student.ID);
=======
                    SW.WriteLine(group.ID + " " + student.Surname + " " + student.ID);
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89

                }
                if (course.Language == " " && group.ID == -1)
                {
<<<<<<< HEAD
                    SW.WriteLine(" " + " " + " " + " " + " " + student.Surname + " " + student.ID);
=======
                    SW.WriteLine(student.Surname + " " + student.ID);
>>>>>>> 3d752a7afcb25e17ff273f7ebc2526b427f67c89

                }

            }
            SW.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}
