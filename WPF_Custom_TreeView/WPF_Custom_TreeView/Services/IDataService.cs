using System.Collections.Generic;

namespace WPF_Custom_TreeView.Services;

public interface IDataService<T> where T : class
{
    void AddPerson(T person);
    IEnumerable<T> GetAll();
}
