using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CustodioUIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _scannerMessage = "";

        private string _textMessage = Constants.MainWindow.TEXT_MSG;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ScannerMessage
        {
            get { return _scannerMessage; }
            set
            {
                _scannerMessage = value;
                OnPropertyChanged(Constants.MainWindow.OPC_SCANNER_MSG);
            }
        }

        public string TextMessage
        {
            get { return _textMessage; }
            set
            {
                _textMessage = value;
                OnPropertyChanged(Constants.MainWindow.OPC_TEXT_MSG);
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (stepsInput.Text != string.Empty && Int32.TryParse(stepsInput.Text, out int steps))
            {
                try
                {
                    int numberOfCombinations = Calculate.WaysToClimb(steps);

                    TextMessage = numberOfCombinations + Constants.MainWindow.NEW_TEXT_MSG_1 + steps + Constants.MainWindow.NEW_TEXT_MSG_2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(Constants.Errors.INT_PARSE_ERROR_MSG);
            }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] SHA256Result = Helper.GetHashSha256(openFileDialog.FileName);

                string hashString = Helper.ConvertByteToString(SHA256Result);

                ApiCalls.ApiCheckIfFileExist(hashString, openFileDialog.FileName);
            }
        }

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void stepsInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnCalculate_Click(sender, e);
            }
        }
    }
}