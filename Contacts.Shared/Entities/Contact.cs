
using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Shared.Entities
{
    public class Contact: BaseEntity
    {
        [Required]
        [Range(1,3)]
        public InfoType Type { get; set; }

        [MaxLength(200,ErrorMessage ="200 karakterden fazla giremezsiniz")]
        [Required]
        public string Info { get; set; }

        [Required]
        public Guid PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
