using Contact.Model;

namespace Contact.Repository
{
    public interface IContactRepository
    {
        public List<Contact.Model.Contact> GetAll();
        Contact.Model.Contact GetById(int id);

    }
}
