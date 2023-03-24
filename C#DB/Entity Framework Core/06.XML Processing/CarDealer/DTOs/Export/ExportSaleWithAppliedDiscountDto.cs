using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("sale")]
    public class ExportSaleWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarWithSaleDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; } = null!;
    }
}
