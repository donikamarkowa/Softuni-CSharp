﻿using AutoMapper;
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

            //string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            //string result = ImportProducts(context, inputXml);

            string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            string result = ImportCategories(context, inputXml);    
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

        ////Problem 02
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
    }
}