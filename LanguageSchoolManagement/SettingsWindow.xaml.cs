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
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public int SliderValue;
        public SettingsWindow()
        {
            InitializeComponent();
            SimulationSlider.Value = Properties.Settings.Default.SimulationSlider;
            SliderValue = (int)SimulationSlider.Value;
        }

        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your setting were succesfully saved!");
            this.Close();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            ((Slider)sender).SelectionEnd = e.NewValue;
            if (this.Owner != null)
            {
                (this.Owner as MainWindow).GenerationLength = (int)e.NewValue;
                Properties.Settings.Default.SimulationSlider =(int)e.NewValue;
                Properties.Settings.Default.Save();                
            }       
            
        }
    }
}
