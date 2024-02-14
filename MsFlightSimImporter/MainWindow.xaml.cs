using ICSharpCode.TreeView;
using MsFlightSimImporter.Models;
using MsFlightSimImporter.Models.Aircraft;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MsFlightSimImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<AircraftNode> AircraftList { get; set; } = new ObservableCollection<AircraftNode>();

        public MainWindow()
        {
            InitializeComponent();
            listView.ItemsSource = AircraftList;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void btnSelectProjectDir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelectFlightSimDir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (sender is Button button && button.Tag is Item item)
            //{
            //    MessageBox.Show($"Button clicked for {item.Title}, {item.Manufacturer}");
            //}
        }

        private async void btnScan_Click(object sender, RoutedEventArgs e)
        {
            Scanner scanner = new Scanner();
            DirectoryInfo scanDir = new DirectoryInfo(tbMsFlightSimDir.Text);
            

            foreach (Aircraft craft in scanner.Scan(scanDir))
            {
                AircraftNode node = new AircraftNode(craft);
                AircraftList.Add(node);
            }
            
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}