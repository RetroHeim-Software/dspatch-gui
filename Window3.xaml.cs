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
using dspatch;

namespace dspatch_gui
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
           
           InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HaxxStationBannerSave_click(object sender, RoutedEventArgs e)
        {
            DownloadStationPatcher.HaxxStationBanner(haxxStationTextBox.Text, haxxStationTextBox2.Text, haxxStationTextBox3.Text);
            if (!DownloadStationPatcher.title.Equals("HaxxStation") || !DownloadStationPatcher.subTitle1.Equals("By Gericom, shutterbug2000") || !DownloadStationPatcher.subTitle2.Equals("and Apache Thunder"))
            {
                MessageBox.Show("You have successfully changed the banner!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong with changing the banner!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
