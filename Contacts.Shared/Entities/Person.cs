using System.Collections.Generic;

namespace Contacts.Shared.Entities
{
    public class Person: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<Contact> ContactData { get; set; }
    }
}
