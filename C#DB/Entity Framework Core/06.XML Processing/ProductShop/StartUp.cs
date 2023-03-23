using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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

            //string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            //string result = ImportProducts(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            //string result = ImportCategories(context, inputXml);    

            //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, inputXml);  

            //string result = GetProductsInRange(context);

            string result = GetSoldProducts(context);
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

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            StringReader reader = new StringReader(inputXml);
            var productDtos = (ImportProductDto[])xmlSerializer.Deserialize(reader);

            ICollection<Product> products = mapper.Map<Product[]>(productDtos);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            StringReader reader = new StringReader(inputXml);
            ImportCategoryDto[] categoryDtos = (ImportCategoryDto[])serializer.Deserialize(reader);
            ICollection<Category> categories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                categories.Add(category);   
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}"; 
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            StringReader reader = new StringReader(inputXml);
            ImportCategoryProductDto[] categoryProductDto = (ImportCategoryProductDto[])serializer.Deserialize(reader);
            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var cpDto in categoryProductDto)
            {
                if (context.Categories.Find(cpDto.CategoryId) == null 
                    || context.Products.Find(cpDto.ProductId) == null)
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cpDto);
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));
            using var writer = new StringWriter();  

            serializer.Serialize(writer, productsInRange, namespaces);
            return writer.ToString();
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldItems = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold
                                .Where(p => p.Buyer != null)
                                .Select(p => new ExportProductsOnUser()
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportUserWithProductsDto[]), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            using var writer = new StringWriter();
            serializer.Serialize(writer, usersWithSoldItems, namespaces);

            return writer.ToString();
        }
    }
}