using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(dbContext, inputJson);

            //string result = GetProductsInRange(dbContext);

            string result = GetSoldProducts(dbContext);
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

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesProductsDto = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var cp in categoriesProductsDto)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cp);
                categoryProducts.Add(categoryProduct);
            }
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}"; ;
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(sp => sp.BuyerId != null)
                    .Select(sp => new
                    {
                        name = sp.Name,
                        price = sp.Price,
                        buyerFirstName = sp.Buyer.FirstName,
                        buyerLastName = sp.Buyer.LastName
                    })
                    .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }
    }
}