using Contact.Data;

namespace Contact.Repository
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {

        private readonly MyContext _context;

        public ContactDetailsRepository(MyContext context)
        {
            _context = context;
        }

        public List<Contact.Model.ContactDetail> GetAll()
        {
            return _context.ContactDetail.ToList();
        }

        public Contact.Model.ContactDetail GetById(int id)
        {
            return _context.ContactDetail.Where(detail => detail.DetailId == id).FirstOrDefault();
        }
    }
}


