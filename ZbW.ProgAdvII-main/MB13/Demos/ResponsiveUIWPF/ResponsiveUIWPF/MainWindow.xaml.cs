using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ResponsiveUIWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void startCalculcationButton_Click(object sender, RoutedEventArgs e) {
            int number;
            if (int.TryParse(this.numberTextBox.Text, out number)) {
                this.calculationResultLabel.Content = "(computing)";
                Task.Factory.StartNew(() => {
                    int result = LongCalculation(number);
                    this.Dispatcher.BeginInvoke(new ThreadStart(() => {
                        this.calculationResultLabel.Content = result.ToString();
                    }));
                });
            }
        }










        //private async void startCalculcationButton_Click(object sender, RoutedEventArgs e) {
        //    int number;
        //    if (int.TryParse(this.numberTextBox.Text, out number)) {
        //        this.calculationResultLabel.Content = "(computing)";
        //        var result = await Task<int>.Factory.StartNew(() => this.LongCalculation(number));
        //        this.calculationResultLabel.Content = result.ToString();
        //    }
        //}

        private int LongCalculation(int number) {
            var sleep = number * 1000;
            Thread.Sleep(sleep);
            return sleep;
        }
    }
}
