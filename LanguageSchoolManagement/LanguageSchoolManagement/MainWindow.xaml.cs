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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Group> Groups;//Список всех группп.
        Student student;
        Application application;
        public MainWindow()
        {
            InitializeComponent();
            Groups = new List<Group>();
            application = new Application("","",0,0,0);
        }

        private void TextBox_Surname(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_Name(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonClickInfo(object sender, RoutedEventArgs e)
        {
            //Формируем заявку:
            application.Surname = TextSurname.Text;//Заполняем фамилию.
            string Name = TextName.Text;//Просто так для красоты, но возможно где-то потребуется.
            //Заполняем пунтк интенсивность в заявке:
            if(ChoiceIntensity.Text == "Intensive")
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
            //MessageBox.Show(application.Surname);
            //MessageBox.Show(application.Language);
            //MessageBox.Show(application.Intensity.ToString());
            //MessageBox.Show(application.Level.ToString());
            Group grup = new Group(0,application.Language, application.Level, application.Intensity);


            //С алгоритмом подбора группы как-то проблемно, не очень понимаю как сделать с оптимальным кол-вом
            //учеников, а по тому, что написано ниже вообще бесконечно будут создаваться новые группы.
            //Подбираем группу:
            for(int i = 0; i < Groups.Count; i++)
            {
                //Сверяем все параметры:
                if (Groups[i].Language == application.Language)
                {
                    if(Groups[i].Level == application.Level)
                    {
                        if (Groups[i].Intensity == application.Intensity)
                        {
                            if (Groups[i].Amount < 10)//Проверяем численность группы, если меньше 10 чел., то добавляем еще человека.
                            {
                                Groups[i].Amount++;
                                
                            }
                            else //если больше 10, то выполняем это:
                            {
                                grup.Amount = 4;//В новую группу добавляем 4 людей из старой.
                                Groups[i].Amount = Groups[i].Amount - 4;//Вычитаем из переполненной группы 4 людей.
                                Groups.Add(grup);//Добавляем новую группу.

                            }
                        }
                    }
                }
            }


        }
    }
}
