using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("parts")]
    public class ExportListPartsForCar
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }

       
    }
}
