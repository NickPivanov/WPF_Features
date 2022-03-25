using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_ValidationRuleDemo.Controls
{
    /// <summary>
    /// Interaction logic for ContactsControl.xaml
    /// </summary>
    public partial class ContactsControl : UserControl
    {
        public ContactsControl()
        {
            InitializeComponent();
            Contacts = new Dictionary<string, string>
            {
                {"89994559797", "job" },
                {"+7955789456", "pers." },
                {"89994559711", "pers." }
            };
            DataContext = this;
        }

        public Dictionary<string, string> Contacts { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
