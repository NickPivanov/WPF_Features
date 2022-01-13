using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Custom_TreeView.Models
{
    public class PersonItem
    {
        public Person Person { get; set; }
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public IList<string> Properties { get; set; }
        public PersonItem(Person person)
        {
            Person = person;
            Description = $"{Person.FirstName} {Person.LastName}";
            Properties = new List<string>();
        }
    }
}
