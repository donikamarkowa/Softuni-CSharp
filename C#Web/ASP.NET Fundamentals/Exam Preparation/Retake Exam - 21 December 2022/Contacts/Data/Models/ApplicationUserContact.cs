using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    public class ApplicationUserContact
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }
        public Contact Contact { get; set; } = null!;
    }
}

//•	ApplicationUserId – a  string, Primary Key, foreign key (required)
//•	ApplicationUser – ApplicationUser
//•	ContactId – an integer, Primary Key, foreign key (required)
//•	Contact – Contact

