namespace Contacts.Data.Entities
{
    public class Contact: BaseEntity
    {
        public InfoType Type { get; set; }
        public string Info { get; set; }
    }
}
