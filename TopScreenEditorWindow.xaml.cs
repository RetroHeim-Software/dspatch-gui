using System.Windows;
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
            string[] changedArray, defaultArray;
            changedArray = new string[2] { topTextBox.Text, top1TextBox.Text };
            defaultArray = new string[2] { DownloadStationPatcher.top, DownloadStationPatcher.top1 };
            bool isValid = true;
            for (short i = 0; i < changedArray.Length; i++)
            {
                isValid = validateTop(defaultArray[i], changedArray[i], i, isValid);
            }
            if (isValid)
            {
                DownloadStationPatcher.HaxxStationTop(topTextBox.Text, top1TextBox.Text);
                if (DownloadStationPatcher.top.Equals(changedArray[0]) && DownloadStationPatcher.top1.Equals(changedArray[1]))
                {
                    MessageBox.Show("You have successfully changed the Top Screen!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong with changing the Top Screen! Since this is not supposed to happen, please report this issue on github!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

            private bool validateTop(string def, string changed, short count, bool _isValid)
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
