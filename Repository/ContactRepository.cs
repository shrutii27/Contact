using Contact.Data;
using Contact.Model;
using Microsoft.EntityFrameworkCore;

namespace Contact.Repository
{
   
    public class ContactRepository : IContactRepository
    {
        private readonly MyContext _context;
        public ContactRepository(MyContext context)
        {
            _context = context;
        }

        public List<Contact.Model.Contact> GetAll()
        {
            return _context.Contact.Where(Contact => Contact.IsActive == true)
                 .ToList();
        }

        public Contact.Model.Contact GetById(int id)
        {
            return _context.Contact.FirstOrDefault(contact => contact.ContactId == id);
        }

        
    }
}


