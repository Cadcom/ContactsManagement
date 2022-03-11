using Contacts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Data.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(35).IsRequired();
            builder.Property(x => x.Company).HasMaxLength(150);
        }
    }
}
