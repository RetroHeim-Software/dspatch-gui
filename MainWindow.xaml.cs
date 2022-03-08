using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;
using dspatch;
using dspatch.Nitro;


namespace dspatch_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static byte[] dsHash = //Hash of the DS Download Station ROM
        {
            0xF1, 0x8B, 0x55, 0xF3, 0xE1, 0x25, 0x9C, 0x03, 0xE1, 0x0D, 0x0E, 0xCB,
            0x54, 0x96, 0x93, 0xB4, 0x29, 0x05, 0xCE, 0xB5
        };

        private Boolean checkHash(string rom)
        {
            if (rom == "")
            {
                return false;
            }
            byte[] dsdata = File.ReadAllBytes(rom);
            byte[] sha1 = SHA1.Create().ComputeHash(dsdata);
            for (int i = 0; i < 20; i++)
            {
                if (sha1[i] != dsHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean createROM()
        {
            // Make sure everything is filled out properly
            if (checkHash(inputTextBox.Text) == false)
            {
                MessageBox.Show("You aren't using the correct DS Download Station ROM!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (outputTextBox.Text == "")
            {
                MessageBox.Show("You did not assign a location for the patched ROM to be saved to!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (romListBox.HasItems == false)
            {
                MessageBox.Show("You did not add any ROMs to include in the patched DS Download Station!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (romListBox.Items.Count > 10)
            {
                MessageBox.Show("You added too many ROMs to include in the patched DS Download Station!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            byte[] dsdata = File.ReadAllBytes(inputTextBox.Text);
            DownloadStationPatcher p = new DownloadStationPatcher(new NDS(dsdata));
            foreach(var r in romListBox.Items)
                p.AddRom(new NDS(File.ReadAllBytes(r.ToString())));
            byte[] finalResult = p.ProduceRom().Write();
            File.Create(outputTextBox.Text).Close();
            File.WriteAllBytes(outputTextBox.Text, finalResult);
            return true;
        }

        private void bar_Credits_Click(object sender, RoutedEventArgs e)
        {
            CreditsWindow credits = new CreditsWindow();
            credits.Show();
        }
        private void bar_HaxxStation_Click(object sender, RoutedEventArgs e)
        {
            NameEditorWindow name = new NameEditorWindow();
            name.Show();
        }

        private void bar_HaxxStationBanner_Click(object sneder, RoutedEventArgs e)
        {
            BannerEditorWindow banner = new BannerEditorWindow();
            banner.Show();
        }

        private void bar_HaxxStationTopScreen_Click(object sneder, RoutedEventArgs e)
        {
            TopScreenEditorWindow top = new TopScreenEditorWindow();
            top.Show();
        }

        private void downloadStationROMOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Usable Files (*.nds;*.srl)|*.nds;*.srl|All Files (*.*)|*.*";
            if (open.ShowDialog() == true)
            {
                inputTextBox.Text = open.FileName;
            }

            // Green: #FF33B439
            // Red: #FFAE0000
            // Checks if the correct ROM was inputted.
            if (checkHash(open.FileName) == false && inputTextBox.Text != "")
            {
                verifiedROM.Foreground = new SolidColorBrush(Color.FromRgb(0xB3, 0x00, 0x00));
                verifiedROM.Content = "Bad ROM!";
            }
            else if (checkHash(open.FileName) == true)
            {
                verifiedROM.Foreground = new SolidColorBrush(Color.FromRgb(0x2D, 0x91, 0x39));
                verifiedROM.Content = "Good ROM!";
            }
        }


        // Quits.
        private void bar_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Saves rom files.
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "NDS ROM (*.nds)|*.nds|All Files (*.*)|*.*";

            if (save.ShowDialog() == true)
            {
                outputTextBox.Text = save.FileName;
            }
        }

        private void addROMButton_Click(object sender, RoutedEventArgs e)
        {
            // Checks if an ok amount of roms was used. Could potentially make it more efficient and increase the total capacity.
            if (romListBox.Items.Count >= 10)
            {
                MessageBox.Show("You cannot add more than 10 ROMs to include in the patched DS Download Station!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Opens a window to select a rom or multiple.
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "All Usable Files (*.nds;*.srl)|*.nds;*.srl";
                if (open.ShowDialog() == true)
                {
                    romListBox.Items.Add(open.FileName);
                }
            }
        }

        // Creates the new download station ROM.
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (createROM() == true)
            {
                MessageBox.Show("Patched ROM successfully saved to " + outputTextBox.Text + "!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
