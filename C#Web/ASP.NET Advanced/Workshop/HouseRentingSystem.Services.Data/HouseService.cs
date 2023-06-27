namespace HouseRentingSystem.Services.Data
{
    using HouseRentingSystem.Services.Data.Interfaces;
    using HouseRentingSystem.Web.Data;
    using HouseRentingSystem.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext dbContext;
        public HouseService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
