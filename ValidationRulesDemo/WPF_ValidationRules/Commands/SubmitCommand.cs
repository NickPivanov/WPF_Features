using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_ValidationRules.ViewModels;

namespace WPF_ValidationRules.Commands
{
    public class SubmitCommand : ICommand
    {
        private readonly IPViewModel _viewModel;
        public event EventHandler? CanExecuteChanged;
        public SubmitCommand(IPViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (IPAddress.TryParse(_viewModel.IPAddressInput, out IPAddress ipAddress))
                MessageBox.Show($"Valid IP: {ipAddress}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Invalid IP: {ipAddress}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
