using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class ImportPartForCarDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
