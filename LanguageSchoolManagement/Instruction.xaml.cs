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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        bool validate = false;
        public Menu()
        {
            InitializeComponent();
        }
        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonTranslateClick(object sender, RoutedEventArgs e)
        {
            if (validate == true)
            {
                Highline.Text = "Reminder";
                Highline.FontSize = 20;
                TextBlock.Text = @"This application simulates the work of foreign language courses. It allows you to visually consider the process of dividing students into groups according to the following rules:

1) Foreign language courses offer instruction in several foreign languages at several levels and with varying degrees of intensity.

2) Each listener can be enrolled in several languages, and for each language he can have his own level and intensity.

3) Classes can be individual and group

To correctly simulate this process, it is necessary to choose desired simulation length in setting window.";
                validate = false;
                this.FontSize = 15;
                this.Title = "Instructions";
            }
            else
            {
                this.Title = "Инструкции";
                Highline.Text = "Памятка";
                Highline.FontSize = 20;
                TextBlock.Text = @"Данное приложение моделирует работу курсов иностранного языка. Оно позволяет наглядно рассмотреть процесс разбиения учеников на группы по следующим правилам:

1)	Курсы иностранного языка предлагают обучение нескольким иностранным языкам на нескольких уровнях и с разной степенью интенсивности.

2)	Каждый слушатель может быть записан на обучение нескольким языкам, причем для каждого языка у него может быть свой уровень и интенсивность.

3)	Занятия могут быть индивидуальные и групповые

 Чтобы корректно смоделировать этот процесс, необходимо выбрать желаемую продолжительность моделирования в окне настройки.";
                validate = true;
                this.FontSize = 15;
            }
        }
    }
}
