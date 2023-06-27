namespace HouseRentingSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();   
            this.RentedHouses = new HashSet<House>();  
        }

        public virtual ICollection<House> RentedHouses { get; set; }
    }
}
