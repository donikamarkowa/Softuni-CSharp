using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Category")]
    public class ExportCategoryWithProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("count")]
        public int CountProducts { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
