namespace HouseRentingSystem.Web.ViewModels.House
{
    using HouseRentingSystem.Web.ViewModels.Category;
    using System.ComponentModel.DataAnnotations;

    using static HouseRentingSystem.Common.EntityValidationsConstants.House;
    public class HouseFormModel
    {
        public HouseFormModel()
        {
            this.Categories = new HashSet<HouseSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLenth)]
        [Display(Name = "Image Link ")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PricePerMonthMinValue, PricePerMonthMaxValue)]
        [Display(Name = "Monthly Price")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<HouseSelectCategoryFormModel> Categories { get; set; }
    }
}
