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
        
        public MainWindow()
        {
            InitializeComponent();
            Test t = new Test();
            t.ShowDialog();
        }
        private void ButtonRulesClick(object sender, RoutedEventArgs e)
        {
            var wds = new Menu();
            wds.Owner = this;
            wds.ShowDialog();

        }
        private void ButtonClickInfo(object sender, RoutedEventArgs e)
        {
            if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
               ChoiceLevel.SelectedIndex == -1 || ChoiceType.SelectedIndex == -1)
            {
                var wds = new Mistake();
                wds.Owner = this;
                wds.ShowDialog();
            }
            else
            {
                var wds = new Result();
                wds.Owner = this;
                wds.ShowDialog();
            }
        }
        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            //if (ChoiceLanguage.SelectedIndex == -1 || ChoiceIntensity.SelectedIndex == -1 ||
            //    ChoiceLevel.SelectedIndex == -1 || ChoiceType.SelectedIndex == -1)
            //{
            //    var wds = new Mistake();
            //    wds.Owner = this;
            //    wds.ShowDialog();
            //}
            //else
            {
                var wds = new VerificationWindow();
                wds.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                this.Hide();
                wds.Owner = this;
                wds.ShowDialog();

            }
           
        }
    }
}
