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
        private LanguageSchool languageSchool;
        public Info(LanguageSchool l)
        {
            InitializeComponent();
            languageSchool = l;
            int CurrentRow = 0;
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            InfoGrid.RowDefinitions.Add(new RowDefinition());
            CurrentRow++;
            TextBox t = new TextBox();

            t.IsReadOnly = true;
            t.TextWrapping = TextWrapping.Wrap;
            t.Margin = new Thickness(20, 0, 0, 0);
            Grid.SetColumn(t, 0);
            Grid.SetRow(t, 1);
            t.Text = "Изучаемые языки:";
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
            Courseb.Margin = new Thickness(20, 0, 0, 0);
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
                    if ((InfoGrid.Children[i] as FrameworkElement).Margin.Left == (InfoGrid.Children[InfoGrid.Children.IndexOf(PressedButton)] as FrameworkElement).Margin.Left + 20)
                    {
                        (InfoGrid.Children[i] as FrameworkElement).Visibility = Visibility.Collapsed;
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
    }

}
