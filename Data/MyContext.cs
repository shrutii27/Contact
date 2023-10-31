using Contact.Model;
using Microsoft.EntityFrameworkCore;



namespace Contact.Data
{
    public class MyContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact.Model.Contact> Contact { get; set; }
        public DbSet<ContactDetail> ContactDetail { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }



    }
}
