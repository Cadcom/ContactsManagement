using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Shared.Entities
{
    public class Person: BaseEntity
    {
        [MinLength(3, ErrorMessage = "An ez 3 karakter girmelisiniz")]
        [MaxLength(25),Required]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "An ez 2 karakter girmelisiniz")]
        [MaxLength(30),Required]
        public string Surname { get; set; }

        [MaxLength(150)]
        public string Company { get; set; }
        public virtual List<Contact> ContactData { get; set; }
    }
}
