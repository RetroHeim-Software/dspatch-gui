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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
           
           InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void haxxStationhaxxStationNameSave_click(object sender, RoutedEventArgs e)
        {
            if (haxxStationTextBox.Equals(""))
            {
                DownloadStationPatcher.HaxxStationServerName(DownloadStationPatcher.haxxStationServer);
            }
            else
            {

                DownloadStationPatcher.HaxxStationServerName(haxxStationTextBox.Text);
            }
        }
    }
}
