using System;
using System.Windows.Controls;

namespace WPF_Custom_TreeView.Commands
{
    public class ItemSelectedCommand : CommandBase
    {
        private Action<object> SetSelectedPerson;
        public ItemSelectedCommand(Action<object> setSelectedPerson) => SetSelectedPerson = setSelectedPerson;
        public override void Execute(object parameter)
        {
            if (parameter == null || parameter.GetType() != typeof(TreeViewItem))
                return;

            SetSelectedPerson((parameter as TreeViewItem)?.Header);
        }
    }
}
