using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Lab_4
{
    public partial class Window : Form
    {
        private List<string> wordList = new List<string>();
        private int wordsCount = 0;
        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Choose file";
                openFile.Filter = "Text files (*.txt)|*.txt";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;

                Parser parser = new Parser();

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // замер времени загрузки и сохранения в список
                        Stopwatch loadTime = new Stopwatch();
                        loadTime.Start();
                        string filePath = openFile.FileName;
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        wordList = parser.Parse(fileContent);

                        loadTime.Stop();
                        // преобразование замеренного времени
                        var ts = loadTime.Elapsed;
                        string parseLoadTime = $"{ts.Seconds} s {ts.Milliseconds} ms {ts.Nanoseconds} ns";

                        label1.Text = string.Empty;
                        foreach (var x in wordList) label1.Text += $"\n{x}";
                        label1.Text += "\n\nВремя загрузки и чтения: " + parseLoadTime;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string wordToFind = textBox2.Text;
            string result = string.Empty;
            int resultPosition = -1;
            if (wordToFind != string.Empty)
            {
                if (wordList.Contains(wordToFind))
                {
                    // Замер времени поиска слова в списке
                    Stopwatch searchTime = new Stopwatch();
                    searchTime.Start();
                    foreach (var x in wordList)
                    {
                        if (x == wordToFind)
                        {
                            searchTime.Stop();
                            result = x;
                            resultPosition = wordList.IndexOf(result);
                        }
                    }

                    // Преобразование замеренного времени
                    var ts = searchTime.Elapsed;
                    string parseSearchTime = $"{ts.Seconds} s {ts.Milliseconds} ms {ts.Nanoseconds} ns";

                    label2.Text = "Нашлось: " + result + " на " + (resultPosition + 1) + " позиции";
                    label2.Text += "\n\nВремя поиска слова: " + parseSearchTime;
                }
                else
                {
                    label2.Text = "В списке нет слова '" + wordToFind + "'\nПроверьте правиьлность введенных данных!";
                }
            }
            else
            {
                label2.Text = "Введите в поле слово, которое хотите найти!";
            }
        }
    }
}
