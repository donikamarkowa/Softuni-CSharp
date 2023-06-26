using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
              .Entity<Contact>()
              .HasData(new Contact()
              {
                  Id = 1,
                  FirstName = "Bruce",
                  LastName = "Wayne",
                  PhoneNumber = "+359881223344",
                  Address = "Gotham City",
                  Email = "imbatman@batman.com",
                  Website = "www.batman.com"
              });


            builder.Entity<ApplicationUserContact>(e =>
            {
                e.HasKey(uc => new { uc.ApplicationUserId, uc.ContactId });
            });

            base.OnModelCreating(builder);
        }
    }
}