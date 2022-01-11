using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Custom_TreeView.ViewModels;

public class MainViewModel : ViewModelBase
{
    public CustomControlViewModel CustomControlViewModel { get; private set; }
    public MainViewModel()
    {
        CustomControlViewModel = new CustomControlViewModel();
    }
}
