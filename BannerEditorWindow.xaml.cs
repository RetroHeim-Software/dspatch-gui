using System.Windows;
using dspatch;

namespace dspatch_gui
{
    /// <summary>
    /// Interaction logic for BannerEditorWindow.xaml
    /// </summary>
    public partial class BannerEditorWindow : Window
    {
        public BannerEditorWindow()
        {

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HaxxStationBannerSave_click(object sender, RoutedEventArgs e)
        {
            string[] changedArray, defaultArray;
            changedArray = new string[3] { titleTextBox.Text, subTitle1TextBox.Text, subTitle2TextBox.Text };
            defaultArray = new string[3] { DownloadStationPatcher.title, DownloadStationPatcher.subTitle1, DownloadStationPatcher.subTitle2 };
            bool isValid = true;
            for (short i = 0; i < 3; i++)
            {
                isValid = validateBanner(defaultArray[i], changedArray[i], i, isValid);
            }
            if (isValid)
            {
                DownloadStationPatcher.HaxxStationBanner(changedArray[0], changedArray[1], changedArray[2]);
                if (DownloadStationPatcher.title.Equals(changedArray[0]) && DownloadStationPatcher.subTitle1.Equals(changedArray[1]) && DownloadStationPatcher.subTitle2.Equals(changedArray[2]))
                {
                    MessageBox.Show("You have successfully changed the banner!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    MessageBox.Show("Something went wrong with changing the banner! Since this is not supposed to happen, please report this issue on github!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool validateBanner(string def, string changed, short count, bool _isValid)
        {
            Validator validate = new Validator();
            bool isValid = validate.validateChanges(def, changed, count, _isValid);
            if (!isValid)
            {
                MessageBox.Show("textbox " + ++count + " is too small. Must match original length. Just try typing!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isValid;
        }
    }
}
