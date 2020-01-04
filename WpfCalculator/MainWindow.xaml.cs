using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _result;
        public int Result { get { return _result; } set { _result = value; OnPropertyChanged(); } }

        private string _log;
        public string Log { get { return _log; } set { _log = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
            DataContext = this;
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Log = "";
            Result = 0;
            UncheckAllOperators();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Log))
            {
                Log = Log.Substring(0, Log.Length - 1);
            }
        }

        private void CheckToggleButtons(ToggleButton buttonToCheck)
        {
            UncheckAllOperators();
            buttonToCheck.IsChecked = true;
        }

        private void UncheckAllOperators()
        {
            Divide_Button.IsChecked = false;
            Multiply_Button.IsChecked = false;
            Subtract_Button.IsChecked = false;
            Addition_Button.IsChecked = false;
        }

        private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckToggleButtons((ToggleButton)sender);
            DoDivide();
        }

        private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckToggleButtons((ToggleButton)sender);
            DoMultiply();
        }

        private void Subtract_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckToggleButtons((ToggleButton)sender);
            DoSubtract();
        }

        private void Addition_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckToggleButtons((ToggleButton)sender);
            DoAddition();
        }

        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Divide_Button.IsChecked == true)
            {
                DoDivide();
            }
            else if (Multiply_Button.IsChecked == true)
            {
                DoMultiply();
            }
            else if (Subtract_Button.IsChecked == true)
            {
                DoSubtract();
            }
            else if (Addition_Button.IsChecked == true)
            {
                DoAddition();
            }
        }

        private void DoAddition()
        {
            if (string.IsNullOrEmpty(Log))
            {
                return;
            }

            Result = int.TryParse(Log, out int value) ? Result + value : 0;
            Log = "";
        }

        private void DoSubtract()
        {
            if (string.IsNullOrEmpty(Log))
            {
                return;
            }

            Result = int.TryParse(Log, out int value) ? Result - value : 0;
            Log = "";
        }

        private void DoMultiply()
        {
            if (string.IsNullOrEmpty(Log))
            {
                return;
            }

            Result = int.TryParse(Log, out int value) ? Result * value : 0;
            Log = "";
        }

        private void DoDivide()
        {
            if (string.IsNullOrEmpty(Log))
            {
                return;
            }

            Result = int.TryParse(Log, out int value) ? Result / (value == 0 ? 1 : value) : 0;
            Log = "";
        }

        private void NumberOne_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "1";
        }

        private void NumberTwo_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "2";
        }

        private void NumberThree_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "3";
        }

        private void NumberFour_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "4";
        }

        private void NumberFive_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "5";
        }

        private void NumberSix_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "6";
        }

        private void NumberSeven_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "7";
        }

        private void NumberEight_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "8";
        }

        private void NumberNine_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "9";
        }

        private void NumberZero_Button_Click(object sender, RoutedEventArgs e)
        {
            Log += "0";
        }

    }
}
