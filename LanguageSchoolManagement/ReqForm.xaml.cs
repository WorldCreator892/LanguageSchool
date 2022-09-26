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

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Логика взаимодействия для ReqForm.xaml
    /// </summary>
    public partial class ReqForm : Window
    {
        List<Group> Groups;//Список всех группп.
        Student student;
        Application application;
        public ReqForm()
        {
            InitializeComponent();
            Groups = new List<Group>();
            application = new Application("", "", 0, 0, 0);
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
            if (ChoiceIntensity.Text == "Intensive")
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
            Group grup = new Group(0, application.Language, application.Level, application.Intensity);
            //Подбираем группу:
            for (int i = 0; i < Groups.Count; i++)
            {
                //Сверяем все параметры:
                if (Groups[i].Language == application.Language && Groups[i].Level == application.Level && Groups[i].Intensity == application.Intensity)
                {
                    if (Groups[i].Amount < 10 && Groups[i].Amount >= 5)//Проверяем численность группы, если меньше 10 чел., то добавляем еще человека.
                    {
                        Groups[i].Amount++;
                    }
                    if (Groups[i].Amount < 5)//Проверяем численность группы, если меньше 5 чел., то добавляем еще человека, но не активируем ее.
                    {
                        Groups[i].Amount++;
                    }
                    else //если больше 10, то выполняем это:
                    {
                        for (int j = i + 1; j < Groups.Count; j++)//Ищем в оставшемся списке группы подходящие.
                        {
                            if (Groups[j].Language == application.Language && Groups[j].Level == application.Level && Groups[j].Intensity == application.Intensity)
                            {
                                if (Groups[j].Amount < 10 && Groups[j].Amount >= 5)//Проверяем численность группы, если меньше 10 чел., то добавляем еще человека.
                                {
                                    Groups[j].Amount++;
                                }
                                if (Groups[j].Amount < 5)//Проверяем численность группы, если меньше 5 чел., то добавляем еще человека, но не активируем ее.
                                {
                                    Groups[j].Amount++;
                                }
                            }
                            else
                            {
                                //Убираем из группы в 10 человек 3 людей, получим группу из 4, но это слишком мало, по этому,
                                //группу мы создадим из 4 человек, но запускать ее не будем пока не найдем 5-ого человека.
                                grup.Amount = 3;//В новую группу добавляем 3 людей из старой.
                                Groups[i].Amount = Groups[i].Amount - 3;//Вычитаем из переполненной группы 3 людей.
                                Groups.Add(grup);//Добавляем новую группу.
                            }
                        }
                    }

                }
            }
        }
    }
}
