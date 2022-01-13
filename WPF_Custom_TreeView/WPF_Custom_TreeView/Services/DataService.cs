using System.Collections.Generic;
using WPF_Custom_TreeView.Models;

namespace WPF_Custom_TreeView.Services;

public class DataService : IDataService<Person>
{
    private IList<Person> _persons;
    public DataService()
    {
        _persons = new List<Person>
            {
                new Person{FirstName = "Luke", LastName = "Skywalker" },
                new Person{FirstName = "Obi Van", LastName = "Kenobi" }
            };
    }

    public void AddPerson(Person person)
    {
        _persons.Add(person);
    }

    public IEnumerable<Person> GetAll()
    {
        return _persons;
    }
}
