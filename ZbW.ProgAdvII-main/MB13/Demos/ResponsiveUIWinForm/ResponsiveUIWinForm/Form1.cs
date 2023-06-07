using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveUIWinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void startCalculcationButton_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(this.numberTextBox.Text, out number))
            {
                this.calculationResultLabel.Text = "(computing)";
                Task.Factory.StartNew(() =>
                {
                    int result = LongCalculation(number);
                    this.calculationResultLabel.BeginInvoke(new ThreadStart(() =>
                    {
                        this.calculationResultLabel.Text = result.ToString();
                    }));
                });
            }
        }















        //private async void startCalculcationButton_Click(object sender, EventArgs e)
        //{
        //    int number;
        //    if (int.TryParse(this.numberTextBox.Text, out number))
        //    {
        //        this.calculationResultLabel.Text = "(computing)";
        //        Debug.WriteLine($"Thread 1: {Thread.CurrentThread.ManagedThreadId}");
        //        var result = await Task<int>.Factory.StartNew(() => this.LongCalculation(number));
        //        Debug.WriteLine($"Thread 3: {Thread.CurrentThread.ManagedThreadId}");
        //        this.calculationResultLabel.Text = result.ToString();
        //        Debug.WriteLine($"Thread 4: {Thread.CurrentThread.ManagedThreadId}");
        //    }
        //}

        private int LongCalculation(int number) {
            Debug.WriteLine($"Thread 2: {Thread.CurrentThread.ManagedThreadId}");
            var sleep = number * 1000;
            Thread.Sleep(sleep);
            return sleep;
        }
    }
}
