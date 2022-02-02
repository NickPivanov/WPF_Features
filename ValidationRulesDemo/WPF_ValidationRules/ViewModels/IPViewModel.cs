using System.ComponentModel;
using System.Windows.Input;
using WPF_ValidationRules.Commands;

namespace WPF_ValidationRules.ViewModels;

public class IPViewModel : INotifyPropertyChanged
{
    private string _ipAddressInput;

    public string IPAddressInput
    {
        get { return _ipAddressInput; }
        set { _ipAddressInput = value; OnPropertyChanged(nameof(IPAddressInput)); }
    }

    public ICommand SubmitIPAddressCommand { get; }

    public IPViewModel()
    {
        SubmitIPAddressCommand = new SubmitCommand(this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
