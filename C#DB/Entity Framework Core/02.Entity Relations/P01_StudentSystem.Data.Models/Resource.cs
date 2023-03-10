using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ResourceNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.ResourceUrlMaxLength)]
        [Column(TypeName = "VARCHAR")]
        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Resource))]
        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;
    }
}
