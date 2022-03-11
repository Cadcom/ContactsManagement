using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid UUID { get; set; }
    }
}
