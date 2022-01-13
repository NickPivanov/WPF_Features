using System.Collections.ObjectModel;
using WPF_Custom_TreeView.Models;
using WPF_Custom_TreeView.Services;

namespace WPF_Custom_TreeView.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDataService<Person> _dataService;
    private ObservableCollection<Person> _personCollection;
    
    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
    }

    private string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
    }

    private string _personProperty;
    public string PersonProperty
    {
        get { return _personProperty; }
        set { _personProperty = value; OnPropertyChanged(nameof(PersonProperty)); }
    }


    public CustomControlViewModel CustomControlViewModel { get; private set; }
    public MainViewModel(IDataService<Person> dataService)
    {
        _dataService = dataService;
        _personCollection = new ObservableCollection<Person>(_dataService.GetAll());
        CustomControlViewModel = new CustomControlViewModel(_personCollection);
    }

    public void AddPerson()
    {
        if (string.IsNullOrEmpty(FirstName)) return;

        var person = new Person { FirstName = FirstName, LastName = LastName };
        _personCollection.Add(person);
        CustomControlViewModel.AddNewPerson(person, PersonProperty);
    }

    public void RemovePerson()
    {
        _personCollection.Remove(CustomControlViewModel.SelectedPerson.Person);
        CustomControlViewModel.RemoveSelectedPerson();
    }

    
}
