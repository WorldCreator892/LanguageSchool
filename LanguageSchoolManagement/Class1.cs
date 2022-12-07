using LanguageSchoolClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace LanguageSchoolManagement
{
    public class Class1
    {

    //    public static void WritingShedulToExcel(LanguageSchool languageSchool, string saveAs)
    //    {
    //        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
    //        app.Visible = true;
    //        Dictionary<int, string> people = new Dictionary<int, string>();
    //        app.SheetsInNewWorkbook = 2;
    //        Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    //        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
    //        sheet.Name = "Student shedule";
    //        sheet.StandardWidth = 30;
    //        sheet.Range["A1"].Value = "Surname";
    //        sheet.Range["B1"].Value = "ID";
    //        sheet.Range["C1"].Value = "Monday";
    //        sheet.Range["D1"].Value = "Tuesday";
    //        sheet.Range["E1"].Value = "Wednesday";
    //        sheet.Range["F1"].Value = "Thursday";
    //        sheet.Range["G1"].Value = "Friday";
    //        sheet.Range["H1"].Value = "Saturday";
    //        sheet.Range["I1"].Value = "Sunday";

    //        int cnt = 2;
    //        for (int i = 0; i < languageSchool.Students.Count; i++)
    //        {
    //            Student student = languageSchool.Students[i];

    //            if (!people.ContainsKey(student.ID))
    //            {
    //                people[student.ID] = student.Surname;
    //                sheet.Range["A" + cnt].Value = student.Surname;
    //                sheet.Range["B" + cnt].Value = student.ID;
    //                int cnt2 = cnt;
    //                for (int j = 0; j < 7; j++)
    //                {
    //                    int cnt3 = cnt2;
    //                    foreach (KeyValuePair<string, int> pair in languageSchool.Students[i].Schedule[j])
    //                    {
    //                        if (j == 0) 
    //                        {
    //                            sheet.Range["C" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt3 > cnt)
    //                                cnt = cnt3;
    //                        }
    //                        if (j == 1)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["D" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                        if (j == 2)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["E" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                        if (j == 3)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["F" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                        if (j == 4)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["G" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                        if (j == 5)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["H" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                        if (j == 6)
    //                        {
    //                            cnt3 = cnt2;
    //                            sheet.Range["I" + cnt3].Value = pair.Key + " в группе " + pair.Value.ToString();
    //                            cnt3++;
    //                            if (cnt2 > cnt)
    //                                cnt = cnt2;
    //                        }
    //                    }
    //                }
    //                cnt++;
    //            }
    //        }
    //        wb.SaveAs(saveAs);
    //    }
    }
}
