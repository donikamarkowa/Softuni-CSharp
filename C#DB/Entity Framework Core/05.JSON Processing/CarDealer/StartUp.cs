﻿using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //string result = ImportParts(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(dbContext, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(dbContext, inputJson);  

            //string result = GetOrderedCustomers(dbContext);

            //string result = GetCarsFromMakeToyota(dbContext);

            string result = GetLocalSuppliers(dbContext);
            Console.WriteLine(result);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var suppliersDto = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = mapper.Map<Supplier[]>(suppliersDto);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var partsDto = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var partDto in partsDto)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }
                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> cars = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            foreach (var car in cars)
            {
                Car currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId)
                {
                    bool isValid = currentCar.PartsCars.FirstOrDefault(x => x.PartId == part) == null;
                    bool isPartValid = context.Parts.FirstOrDefault(p => p.Id == part) != null;

                    if (isValid && isPartValid)
                    {
                        currentCar.PartsCars.Add(new PartCar()
                        {
                            PartId = part
                        });
                    }
                }

                context.Cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var customersDto = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> customers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}."; 
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var salesDto = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> sales = mapper.Map<Sale[]>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject (cars, Formatting.Indented);
        }

        //Problem 16 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented); 
        }
    }
}