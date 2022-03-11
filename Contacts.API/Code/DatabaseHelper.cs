using Contacts.Data;

namespace Contacts.API.Code
{
    public class DatabaseHelper
    {
        private readonly ContactsDBContext dbContext;

        public DatabaseHelper(ContactsDBContext _dbContext)
        {
            dbContext = _dbContext;

            
        }

        
    }
}
