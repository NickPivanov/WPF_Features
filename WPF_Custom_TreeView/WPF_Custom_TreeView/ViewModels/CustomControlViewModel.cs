using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Custom_TreeView.Commands;
using WPF_Custom_TreeView.Models;

namespace WPF_Custom_TreeView.ViewModels;

public class CustomControlViewModel : ViewModelBase
{
    public ObservableCollection<TreeViewItem> People { get; set; }
    public ICommand SetSelectedItemCommand { get; }
    public PersonItem SelectedPerson { get; private set; }

    public CustomControlViewModel(IEnumerable<Person> people)
    {
        People = new ObservableCollection<TreeViewItem>(people.Select(x => CreateItemForTreeView(x)).ToList());

        SetSelectedItemCommand = new ItemSelectedCommand(SetSelectedPerson);
    }

    private TreeViewItem CreateItemForTreeView(Person person)
    {
        var personItem = new PersonItem(person);
        personItem.Properties.Add("Master Jedi");
        return new TreeViewItem() {Header = personItem, ItemsSource = personItem.Properties };
    }
    private void SetSelectedPerson(object item)
    {
        if (item.GetType() != typeof(PersonItem))
            return;
        SelectedPerson = (PersonItem)item;
    }

    public void AddNewPerson(Person person, string prop)
    {
        var personItem = new PersonItem(person);
        personItem.Properties.Add(prop);
        People.Add(new TreeViewItem() { Header = personItem, ItemsSource = personItem.Properties });
    }

    public void SetPersonChecked()
    {
        //some action on TreeViewItem CheckBox is checked
    }

    public void RemoveSelectedPerson()
    {
        People.Remove(People.FirstOrDefault(x => (x.Header as PersonItem)?.Description == SelectedPerson?.Description));
    }
}
