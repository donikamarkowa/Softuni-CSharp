using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(dbContext, inputJson);
            //Console.WriteLine(result);

            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(dbContext, inputJson);
            //Console.WriteLine(result);

            string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            string result = ImportCategories(dbContext, inputJson);
            Console.WriteLine(result);

        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportUserDto[] userDtos =
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var productsDto = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categories = new HashSet<Category>();

            foreach (var categoryDto in categoriesDto)
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


    }
}