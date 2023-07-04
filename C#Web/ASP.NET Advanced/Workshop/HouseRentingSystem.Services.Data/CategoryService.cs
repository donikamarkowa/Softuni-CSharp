namespace HouseRentingSystem.Services.Data
{
    using HouseRentingSystem.Services.Data.Interfaces;
    using HouseRentingSystem.Web.Data;
    using HouseRentingSystem.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly HouseRentingDbContext dbContext;
        public CategoryService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<HouseSelectCategoryFormModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new HouseSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
