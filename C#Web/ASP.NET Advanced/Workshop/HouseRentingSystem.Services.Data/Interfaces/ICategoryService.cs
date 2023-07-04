namespace HouseRentingSystem.Services.Data.Interfaces
{
    using HouseRentingSystem.Web.ViewModels.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
