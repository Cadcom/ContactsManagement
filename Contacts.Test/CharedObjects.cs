using Contacts.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Test
{
    public class CharedObjects : IDisposable
    {
        Person person;
        Contact contact;

        public void Dispose()
        {
        }
    }
}
