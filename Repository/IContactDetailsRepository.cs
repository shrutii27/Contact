using Contact.Model;

namespace Contact.Repository
{
    public interface IContactDetailsRepository
    {
        public List<ContactDetail> GetAll();
        ContactDetail GetById(int id);

    }
}
