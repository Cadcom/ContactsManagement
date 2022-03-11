using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDBContext:DbContext
    {
        public ContactsDBContext(DbContextOptions<ContactsDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsDBContext).Assembly);
        }
    }
}
