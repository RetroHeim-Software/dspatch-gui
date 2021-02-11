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
    /// Interaction logic for TopScreenEditorWindow.xaml
    /// </summary>
    public partial class TopScreenEditorWindow : Window
    {
        public TopScreenEditorWindow()
        {
           
           InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HaxxStationTopSave_click(object sender, RoutedEventArgs e)
        {
            DownloadStationPatcher.HaxxStationTop(haxxStationTextBox.Text, haxxStationTextBox2.Text);
            if (!DownloadStationPatcher.cat.Equals("HaxxStation by Gericom,") || !DownloadStationPatcher.cat1.Equals("shutterbug2000, Apache Thunder"))
            {
                MessageBox.Show("You have successfully changed the Top Screen!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong with changing the Top Screen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
