using Contacts.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDBContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public ContactsDBContext(DbContextOptions<ContactsDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsDBContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("Server=localhost;Database=DBContacts;User Id=postgres;Password=123456", b => b.MigrationsAssembly("Contacts.Data"));
        }

        
    }
}
