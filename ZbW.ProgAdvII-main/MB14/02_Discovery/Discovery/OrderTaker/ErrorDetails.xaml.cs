using OrderRules.RuleChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderTaker {
    public partial class ErrorDetails : Window {
        private List<DynamicOrderRule> errorList;

        public ErrorDetails(List<DynamicOrderRule> brokenRules) {
            InitializeComponent();
            errorList = brokenRules;
            ErrorDetailsListBox.ItemsSource = errorList;
        }

    }
}