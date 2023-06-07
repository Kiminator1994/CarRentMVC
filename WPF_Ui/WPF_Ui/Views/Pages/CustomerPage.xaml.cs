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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;

namespace WPF_Ui.Views.Pages
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : INavigableView<ViewModels.CustomerViewModel>
    {
        public ViewModels.CustomerViewModel ViewModel
        {
            get;
        }

        public CustomerPage(ViewModels.CustomerViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
