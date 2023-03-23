using CarDealer.DTOs.Import;
using System.Collections;
using System.Xml.Serialization;

namespace CarDealer.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T suppliersDto = (T)xmlSerializer.Deserialize(reader);

            return suppliersDto;
        }
        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            T[] suppliersDto = (T[])xmlSerializer.Deserialize(reader);

            return suppliersDto;
        }
    }
}
