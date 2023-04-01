using Boardgames.Data.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id  { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 10.00)]
        public double Rating  { get; set; }

        [Required]
        [Range(2018, 2023)]
        public int YearPublished  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Creator))]   
        public int CreatorId  { get; set; }
        public virtual Creator Creator { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers  { get; set; }
    }
}
