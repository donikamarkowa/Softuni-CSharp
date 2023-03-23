using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            string result = ImportUsers(context, inputXml);
            Console.WriteLine(result);
        }
        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            StringReader reader = new StringReader(inputXml);
            ImportUserDto[] userDtos = (ImportUserDto[])serializer.Deserialize(reader);

            ICollection<User> users = mapper.Map<User[]>(userDtos);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}"; ;
        }
    }
}