namespace HouseRentingSystem.Services.Data.Interfaces
{
    using HouseRentingSystem.Web.ViewModels.Home;
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();
    }
}
