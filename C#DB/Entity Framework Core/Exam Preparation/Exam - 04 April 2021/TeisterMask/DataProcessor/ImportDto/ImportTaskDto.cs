using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]

        public string Name { get; set; } = null!;

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; } = null!;

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; } = null!;

        [XmlElement("ExecutionType")]
        [Required]
        public int ExecutionType { get; set; } 

        [XmlElement("LabelType")]
        [Required]
        public int LabelType { get; set; }
    }
}
