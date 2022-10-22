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
    /// Логика взаимодействия для VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {
        ReqForm wds;
        public VerificationWindow()
        {
            InitializeComponent();
        }

        private void СhosenTextLoader(object sender, RoutedEventArgs e)
        {
           // using (System.Windows.Forms.OpenFileDialog()
            // if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
        }

        private void СhosenMakeNewOne(object sender, RoutedEventArgs e)
        {
            wds = new ReqForm();
            wds.Owner = this;
            wds.Show();
            this.Hide();
        }
    }
}
