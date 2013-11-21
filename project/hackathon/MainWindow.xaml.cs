using System.Windows;
using System.Windows.Controls;
using hackathon.ViewModel;
using hackathon.data;

namespace hackathon
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void KantonInfo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoPane.Abstimmungen = ((MainViewModel) DataContext).Abstimmungen;
            InfoPane.AktivKantone = (Kanton) KantonInfo.Items.CurrentItem;
        }

        private void JahrInfo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoPane.AktivJahr = int.Parse((string) YearInfo.Items.CurrentItem);
        }
    }
}