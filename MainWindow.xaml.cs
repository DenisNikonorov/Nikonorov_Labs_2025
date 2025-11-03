using Microsoft.Win32;
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

namespace firstWPFProgramm
{
    public partial class MainWindow : Window
    {
        public List<string> wordList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose file";
            dialog.Filter = "text files (*.txt) | *.txt";
            
            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                string fileColtent = System.IO.File.ReadAllText(filePath);
                label1.Content = "Слова из файла:\n";
                Parser.ParseInList(fileColtent, wordList);

                foreach (var word in wordList)
                {
                    label1.Content += word + '\n';
                }
                
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string wordToFind = TextBox.Text;
            string result = Search.SearchInList(wordList, wordToFind);
            searchResultLabel.Content = result;
        }
    }
}