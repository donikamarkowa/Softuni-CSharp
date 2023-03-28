using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [Required]
        [XmlElement("ContractStartDate")]
        public DateTime ContractStartDate  { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]

        public DateTime ContractEndDate  { get; set; }

        [Required]
        [XmlElement("PositionType")]
        public PositionType PositionType  { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; } 

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; } = null!;

        [InverseProperty(nameof(TeamFootballer.Footballer))]
        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
