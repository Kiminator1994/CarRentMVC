using System.Threading.Tasks;
using System.Windows;

namespace TestUIThread {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private bool _IsCancelled { get; set; }
    private bool _IsRunning { get; set; }

    private async void StartCalculationButton_Click(object sender, RoutedEventArgs e) {
      if (_IsRunning) {
        _IsCancelled = true;
      } else {
        if (!long.TryParse(baseNumberTextBox.Text, out long initial) ||
                    !long.TryParse(succeedingPrimesTextBox.Text, out long amount)) {
          return;
        }
        _IsRunning = true;
        startCalculationButton.Content = "Cancel";
        await _ComputeNextPrimesAsync(initial, amount);
        progressLabel.Content = _IsCancelled ? "cancelled" : "done";
        startCalculationButton.Content = "Start";
        _IsRunning = false;
        _IsCancelled = false;
      }
    }

    private async Task _ComputeNextPrimesAsync(long inital, long amount) {
      for (var number = inital; number < inital + amount && !_IsCancelled; number++) {
        if (await _IsPrimeAsync(number)) {
          resultListView.Items.Add(number);
        }
        var progress = (number - inital + 1) * 100 / amount;
        progressLabel.Content = progress + "% computed";
      }
    }

    private Task<bool> _IsPrimeAsync(long number) {
      return Task.Run(() => {
        for (long i = 2; i * i <= number; i++) {
          if (number % i == 0) {
            return false;
          }
        }
        return true;
      });
    }
  }
}
