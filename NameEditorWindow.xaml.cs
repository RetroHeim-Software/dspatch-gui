using System.Text;
using System.Windows;
using dspatch;

namespace dspatch_gui
{
    /// <summary>
    /// Interaction logic for NameEditorWindow.xaml
    /// </summary>
    public partial class NameEditorWindow : Window
    {
        public NameEditorWindow()
        {
           
           InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void haxxStationhaxxStationNameSave_click(object sender, RoutedEventArgs e)
        {
            string changedInternalName = internalNameTextBox.Text;
            bool isValid = true;
            isValid = validateName(Encoding.ASCII.GetString(DownloadStationPatcher.haxxStationServer, 0, DownloadStationPatcher.haxxStationServer.Length), changedInternalName, 0, isValid);

            if (isValid)
            {
                DownloadStationPatcher.HaxxStationServerName(changedInternalName);
                if (Encoding.ASCII.GetString(DownloadStationPatcher.haxxStationServer, 0, DownloadStationPatcher.haxxStationServer.Length).Equals(internalNameTextBox.Text))
                {
                    MessageBox.Show("You have successfully changed the internal name!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong with changing the Internal Name! Since this is not supposed to happen, please report this issue on github!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool validateName(string def, string changed, short count, bool _isValid)
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
