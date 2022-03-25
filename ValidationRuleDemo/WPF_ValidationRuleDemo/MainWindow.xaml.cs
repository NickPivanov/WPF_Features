using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF_ValidationRuleDemo.Controls;
using WPF_ValidationRuleDemo.ValidationRules;

namespace WPF_ValidationRuleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            IsEmail = true;
        }

        private bool mIsEmail;
        public bool IsEmail
        {
            get { return mIsEmail; }
            set { mIsEmail = value; OnPropertyChanged(nameof(IsEmail)); SetValidationRule(); }
        }

        private bool mIsPhone;
        public bool IsPhone
        {
            get { return mIsPhone; }
            set { mIsPhone = value; OnPropertyChanged(nameof(IsPhone)); SetValidationRule(); }
        }

        private string mAddressValue;

        public string AddressValue
        {
            get { return mAddressValue; }
            set { mAddressValue = value; OnPropertyChanged(nameof(AddressValue)); }
        }


        private void SetValidationRule()
        {
            Binding binding = BindingOperations.GetBinding(txbTest, TextBox.TextProperty);
                
            binding.ValidationRules.Clear();
            if (IsEmail)
                binding.ValidationRules.Add(new EmailValidationRule());
            else if (IsPhone)
                binding.ValidationRules.Add(new PhoneValidationRule());
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
	    {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
        #endregion

        private void txbTest_GotFocus(object sender, RoutedEventArgs e)
        {
            var contactControl = new ContactsControl();
            grdContacts.Children.Add(contactControl);
            Grid.SetZIndex(grdContacts, Grid.GetZIndex(grdContacts) + 1);
        }

    }
}
