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
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : System.Windows.Window
    {
        private int InfoFieldCount = 0;
        private int GenerLength = 3;        
        private LanguageSchool languageSchool;
        public Info(LanguageSchool l, int GenerationLength)
        {
            GenerLength = GenerationLength;
            InitializeComponent();
            this.ShowSchool(l, GenerationLength);
            
        }

        public void ChangeBtnStateOnPress(object sender, RoutedEventArgs e)
        {
            Button PressedButton = sender as Button;
            if ((bool)PressedButton.Tag == false)
            {
                PressedButton.Content = PressedButton.Content.ToString().Remove(PressedButton.Content.ToString().Length - 22) + "   (скрыть содержимое)";
                PressedButton.Tag = true;
                for (int i = InfoGrid.Children.IndexOf(PressedButton) + 1; i < InfoGrid.Children.Count; i++)
                {
                    if ((InfoGrid.Children[i] as FrameworkElement).Margin.Left == (InfoGrid.Children[InfoGrid.Children.IndexOf(PressedButton)] as FrameworkElement).Margin.Left + 20)
                    {
                        (InfoGrid.Children[i] as FrameworkElement).Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if ((InfoGrid.Children[i] as FrameworkElement).Margin.Left == (InfoGrid.Children[InfoGrid.Children.IndexOf(PressedButton)] as FrameworkElement).Margin.Left)
                        {
                            break;
                        }
                    }

                }
            }
            else
            {
                PressedButton.Content = PressedButton.Content.ToString().Remove(PressedButton.Content.ToString().Length - 22) + " (раскрыть содержимое)";
                PressedButton.Tag = false;
                for (int i = InfoGrid.Children.IndexOf(PressedButton) + 1; i < InfoGrid.Children.Count; i++)
                {
                    if ((InfoGrid.Children[i] as FrameworkElement).Margin.Left >= (InfoGrid.Children[InfoGrid.Children.IndexOf(PressedButton)] as FrameworkElement).Margin.Left + 20)
                    {
                        (InfoGrid.Children[i] as FrameworkElement).Visibility = Visibility.Collapsed;
                        if((InfoGrid.Children[i] as FrameworkElement).Tag != null)
                        {
                            (InfoGrid.Children[i] as FrameworkElement).Tag = false;
                            var t = (InfoGrid.Children[i] as ContentControl);
                            t.Content = t.Content.ToString().Remove(t.Content.ToString().Length - 22) + " (раскрыть содержимое)";
                        }
                    }
                    else
                    {
                        if ((InfoGrid.Children[i] as FrameworkElement).Margin.Left == (InfoGrid.Children[InfoGrid.Children.IndexOf(PressedButton)] as FrameworkElement).Margin.Left)
                        {
                            break;
                        }
                    }


                }
            }
        }
        private void ButtonClickReturn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonClickSaveToExcel(object sender, RoutedEventArgs e)
        {
            string file1 = "C:\\Users\\admin\\Desktop\\LanguageSchool-main\\LanguageSchool.xlsx";
            //Если список языковых школ:
            //List<LanguageSchool> languageSchools = new List<LanguageSchool>();
            //for (int i = 0; i < 5; i++)
            //{
            //    languageSchool = RandomCourseEventsAndGeneration.GenerateLanguageSchool(PossibleSurnames, PossibleLanguages);
            //    languageSchool.ReformCourses();
            //    languageSchools.Add(languageSchool);
            //}
            //WorkWithExcel.WriteListLanguageSchoolToExcel(languageSchools, file1);
            try
            {
                WorkWithExcel.WriteLanguageSchoolToExcel(languageSchool, file1);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Ошибка при сохранении документа. Текущая версия файла может быть сохранена в уже созданный файл при закрытии таблицы.");
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Отсутствует файл для отображения данных. Либо произошла ошибка во время записи.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("Не удается открыть или создать файл.");
            }
            catch(Exception ex)
            {
                var wds = new Mistake();
                wds.ShowDialog();
            }

        }

        private void ShowSchool(LanguageSchool l, int GenerationSteps)
        {
            languageSchool = l;
            int CurrentRow = 0;
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for(int p = 0; p < GenerationSteps + 1; p++)
            {
                l.ReformCourses();
                InfoGrid.RowDefinitions.Add(new RowDefinition());
                CurrentRow++;
                Button Schoolb = new Button(); //работа с кнопкой школы и школами
                Schoolb.Name = "SchoolBtn";
                Schoolb.Tag = false;
                Schoolb.Content = p.ToString() + " шаг моделирования (раскрыть содержимое)";
                Schoolb.Background = Brushes.DarkBlue;
                Schoolb.Foreground = Brushes.White;
                Schoolb.Margin = new Thickness(20, 0, 0, 0);
                Schoolb.HorizontalAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(Schoolb, 0);
                Grid.SetRow(Schoolb, CurrentRow);
                Schoolb.Click += ChangeBtnStateOnPress;
                InfoGrid.Children.Add(Schoolb);
                Thickness SchoolInfoMargin = new Thickness((InfoGrid.Children[InfoGrid.Children.Count - 1] as FrameworkElement).Margin.Left + 20, 0, 0, 0);
                InfoGrid.RowDefinitions.Add(new RowDefinition());
                CurrentRow++;
                TextBox t = new TextBox();
                t.IsReadOnly = true;
                t.TextWrapping = TextWrapping.Wrap;
                t.Margin = SchoolInfoMargin;
                Grid.SetColumn(t, 0);
                Grid.SetRow(t, CurrentRow);
                t.Text = "Изучаемые языки:";
                t.Visibility = Visibility.Collapsed;
                for (int i = 0; i < l.Languages.Count; i++)
                {
                    t.Text = t.Text + " " + l.Languages[i];
                }
                t.Text += Environment.NewLine + " Количество курсов: " + l.Courses.Count.ToString();
                t.Text += Environment.NewLine + " Количество обучающихся: " + l.Students.Count.ToString();
                InfoGrid.Children.Add(t);
                InfoGrid.RowDefinitions.Add(new RowDefinition());
                CurrentRow++;
                Button Courseb = new Button(); //работа с кнопкой курсов и курсами
                Courseb.Name = "CourseBtn";
                Courseb.Tag = false;
                Courseb.Content = "Курсы (раскрыть содержимое)";
                Courseb.Background = Brushes.DarkBlue;
                Courseb.Foreground = Brushes.White;
                Courseb.Margin = SchoolInfoMargin;
                Courseb.Visibility = Visibility.Collapsed; ;
                Courseb.HorizontalAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(Courseb, 0);
                Grid.SetRow(Courseb, CurrentRow);
                Courseb.Click += ChangeBtnStateOnPress;
                InfoGrid.Children.Add(Courseb);
                Thickness CourseInfoMargin = new Thickness((InfoGrid.Children[InfoGrid.Children.Count - 1] as FrameworkElement).Margin.Left + 20, 0, 0, 0);
                for (int i = 0; i < l.Courses.Count; i++)
                {
                    InfoGrid.RowDefinitions.Add(new RowDefinition());
                    CurrentRow++;
                    TextBox CourseInfo = new TextBox();
                    CourseInfo.IsReadOnly = true;
                    CourseInfo.TextWrapping = TextWrapping.Wrap;
                    CourseInfo.Visibility = Visibility.Collapsed;
                    CourseInfo.Margin = CourseInfoMargin;

                    Grid.SetColumn(CourseInfo, 0);
                    Grid.SetRow(CourseInfo, CurrentRow);
                    CourseInfo.Text = "Информация о курсе: ";
                    CourseInfo.Text += Environment.NewLine + " Изучаемый язык - " + l.Courses[i].Language;
                    CourseInfo.Text += Environment.NewLine + " Стандартная оплата - " + l.Courses[i].StandartPayment.ToString();
                    CourseInfo.Text += Environment.NewLine + " Коэффициент надбавки за индивидуальное обучение - " + l.Courses[i].IndividualCoefficient.ToString();
                    CourseInfo.Text += Environment.NewLine + " Количество обучающихся - " + l.Courses[i].StudentAmount.ToString();
                    CourseInfo.Text += Environment.NewLine + " Количество групп (включая обучающихся индивидуально) - " + l.Courses[i].Groups.Count.ToString();
                    InfoGrid.Children.Add(CourseInfo);
                    InfoGrid.RowDefinitions.Add(new RowDefinition());
                    CurrentRow++;
                    Button Groupb = new Button(); //работа с кнопкой групп и с группами
                    Groupb.Name = "GroupBtn";
                    Groupb.Visibility = Visibility.Collapsed;
                    Groupb.Tag = false;
                    Groupb.Content = "Группы (раскрыть содержимое)";
                    Groupb.Background = Brushes.DarkBlue;
                    Groupb.Foreground = Brushes.White;
                    Groupb.Margin = CourseInfoMargin;
                    Groupb.HorizontalAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(Groupb, 0);
                    Grid.SetRow(Groupb, CurrentRow);
                    Groupb.Click += ChangeBtnStateOnPress;
                    InfoGrid.Children.Add(Groupb);
                    Thickness GroupInfoMargin = new Thickness((InfoGrid.Children[InfoGrid.Children.Count - 1] as FrameworkElement).Margin.Left + 20, 0, 0, 0);
                    for (int j = 0; j < l.Courses[i].Groups.Count; j++)
                    {
                        InfoGrid.RowDefinitions.Add(new RowDefinition());
                        CurrentRow++;
                        TextBox GroupInfo = new TextBox();
                        GroupInfo.IsReadOnly = true;
                        GroupInfo.TextWrapping = TextWrapping.Wrap;
                        GroupInfo.Visibility = Visibility.Collapsed;
                        GroupInfo.Margin = GroupInfoMargin;
                        Grid.SetColumn(GroupInfo, 0);
                        Grid.SetRow(GroupInfo, CurrentRow);
                        GroupInfo.Text = "Информация о группе: ";
                        GroupInfo.Text += Environment.NewLine + " Идентификатор группы - " + l.Courses[i].Groups[j].ID;
                        GroupInfo.Text += Environment.NewLine + " Число обучающихся - " + l.Courses[i].Groups[j].StudentIDs.Count;
                        GroupInfo.Text += Environment.NewLine + " Уровень обучения - " + l.Courses[i].Groups[j].Level;
                        GroupInfo.Text += Environment.NewLine + " Интенсивность обучения - " + l.Courses[i].Groups[j].Intensity;
                        GroupInfo.Text += Environment.NewLine + " Число оставшихся занятий - " + l.Courses[i].Groups[j].RemainingLessons;
                        GroupInfo.Text += Environment.NewLine + " Список обучающихся (по идентификационным номерам): ";
                        if (l.Courses[i].Groups[j].StudentIDs.Count == 1)
                        {
                            GroupInfo.Background = Brushes.LightPink;
                        }
                        foreach (int ID in l.Courses[i].Groups[j].StudentIDs)
                        {
                            GroupInfo.Text += Environment.NewLine + ID;
                        }
                        InfoGrid.Children.Add(GroupInfo);

                    }
                }
                InfoGrid.RowDefinitions.Add(new RowDefinition());
                CurrentRow++;
                Button CourseStud = new Button(); //работа с кнопкой студентов и студентами
                CourseStud.Name = "CourseStudBtn";
                CourseStud.Tag = false;
                CourseStud.Content = "Студенты (раскрыть содержимое)";
                CourseStud.Background = Brushes.DarkBlue;
                CourseStud.Foreground = Brushes.White;
                CourseStud.Margin = SchoolInfoMargin;
                CourseStud.Visibility = Visibility.Collapsed;
                CourseStud.HorizontalAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(CourseStud, 0);
                Grid.SetRow(CourseStud, CurrentRow);
                CourseStud.Click += ChangeBtnStateOnPress;
                InfoGrid.Children.Add(CourseStud);
                Thickness StudentInfoMargin = new Thickness((InfoGrid.Children[InfoGrid.Children.Count - 1] as FrameworkElement).Margin.Left + 20, 0, 0, 0);
                for (int i = 0; i < l.Students.Count; i++)
                {
                    InfoGrid.RowDefinitions.Add(new RowDefinition());
                    CurrentRow++;
                    TextBox StudentInfo = new TextBox();
                    StudentInfo.IsReadOnly = true;
                    StudentInfo.TextWrapping = TextWrapping.Wrap;
                    StudentInfo.Visibility = Visibility.Collapsed;
                    StudentInfo.Margin = StudentInfoMargin;

                    Grid.SetColumn(StudentInfo, 0);
                    Grid.SetRow(StudentInfo, CurrentRow);
                    StudentInfo.Text = "Информация о студенте: ";
                    StudentInfo.Text += Environment.NewLine + " Имя/Фамилия - " + l.Students[i].Surname;
                    StudentInfo.Text += Environment.NewLine + " Присвоенный ID - " + l.Students[i].ID.ToString();
                    InfoGrid.Children.Add(StudentInfo);
                    InfoGrid.RowDefinitions.Add(new RowDefinition());
                    CurrentRow++;
                    Button Applicationb = new Button(); //работа с кнопкой групп и с группами
                    Applicationb.Name = "ApplicationBtn";
                    Applicationb.Visibility = Visibility.Collapsed;
                    Applicationb.Tag = false;
                    Applicationb.Content = "Заявки (раскрыть содержимое)";
                    Applicationb.Background = Brushes.DarkBlue;
                    Applicationb.Foreground = Brushes.White;
                    Applicationb.Margin = StudentInfoMargin;
                    Applicationb.HorizontalAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(Applicationb, 0);
                    Grid.SetRow(Applicationb, CurrentRow);
                    Applicationb.Click += ChangeBtnStateOnPress;
                    InfoGrid.Children.Add(Applicationb);
                    Thickness ApplicationInfoMargin = new Thickness((InfoGrid.Children[InfoGrid.Children.Count - 1] as FrameworkElement).Margin.Left + 20, 0, 0, 0);
                    for (int j = 0; j < l.Students[i].Applications.Count; j++)
                    {
                        InfoGrid.RowDefinitions.Add(new RowDefinition());
                        CurrentRow++;
                        TextBox ApplicationInfo = new TextBox();
                        ApplicationInfo.IsReadOnly = true;
                        ApplicationInfo.TextWrapping = TextWrapping.Wrap;
                        ApplicationInfo.Visibility = Visibility.Collapsed;
                        ApplicationInfo.Margin = ApplicationInfoMargin;
                        Grid.SetColumn(ApplicationInfo, 0);
                        Grid.SetRow(ApplicationInfo, CurrentRow);
                        ApplicationInfo.Text = "Информация о заявке: ";
                        ApplicationInfo.Text += Environment.NewLine + " Выбранный язык - " + l.Students[i].Applications[j].Language;
                        ApplicationInfo.Text += Environment.NewLine + " Выбранная интенсивность обучения - " + l.Students[i].Applications[j].Intensity.ToString();
                        ApplicationInfo.Text += Environment.NewLine + " Выбранный уровень обучения - " + l.Students[i].Applications[j].Level.ToString();
                        ApplicationInfo.Text += Environment.NewLine + " Статус заявки - " + l.Students[i].Applications[j].Status.ToString();
                        ApplicationInfo.Text += Environment.NewLine + " Количество внесенной предоплаты - " + l.Students[i].Applications[j].PayedAmount.ToString();
                        ApplicationInfo.Text += Environment.NewLine + " Время ожидания рассмотрения заявки - " + l.Students[i].Applications[j].WaitingTime.ToString();
                        ApplicationInfo.Text += Environment.NewLine + " Идентификатор приписанной группы (-1 если нет) - " + l.Students[i].Applications[j].GroupID.ToString();
                        InfoGrid.Children.Add(ApplicationInfo);
                    }
                }
            }            
        }
    }

}
