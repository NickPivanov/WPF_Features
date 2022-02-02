namespace WPF_ValidationRules.ViewModels
{
    public class MainViewModel
    {
        public IPViewModel IPViewModel { get; set; }
        public MainViewModel()
        {
            IPViewModel = new IPViewModel();
        }
    }
}
