using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            //string result = ImportParts(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            //string result = ImportCars(context, inputXml);  

            //string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            //string result = ImportCars(context, inputXml);

            //string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            //string result = ImportCustomers(context, inputXml); 

            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //string result = ImportSales(context, inputXml); 

            //string result = GetCarsWithDistance(context);

            //string result = GetCarsFromMakeBmw(context);

            //string result = GetCarsWithTheirListOfParts(context);

            string result = GetTotalSalesByCustomer(context);
            Console.WriteLine(result);
        }
        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            // XmlHelper xmlHelper = new XmlHelper();
            // ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Problem 10 
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlRootAttribute rootAttribute = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), rootAttribute);

            StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partDtos = (ImportPartDto[])xmlSerializer.Deserialize(reader);  

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var partDto in partDtos)
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

            return $"Successfully imported {parts.Count}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            ImportCarDto[] carDtos = (ImportCarDto[])serializer.Deserialize(reader);    

            var cars = carDtos
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    PartsCars = c.PartsCar
                    .Select(p => p.PartId)
                    .Distinct()
                    .Select(d => new PartCar
                    {
                        PartId = d
                    })
                    .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            using var reader = new StringReader(inputXml);
            ImportCustomerDto[] customerDtos = (ImportCustomerDto[])serializer.Deserialize(reader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var customerDto in customerDtos)
            {
                Customer customer = mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);
            ImportSaleDto[] saleDtos = (ImportSaleDto[])serializer.Deserialize(reader);

            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);  
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context
                .Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var carDtos = carsWithDistance
                .Select(c => new ExportCarWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, carDtos, namespaces);

            return writer.ToString();
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsFromMakeBmw = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            var carFromMakeBmwDtos = carsFromMakeBmw
                .Select(c => new ExportCarsFromMakeBmwDtos()
                {
                    Id = c.Id,  
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray(); 

            var namespaces = new XmlSerializerNamespaces(); 
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsFromMakeBmwDtos[]), new XmlRootAttribute("cars"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, carFromMakeBmwDtos, namespaces);

            return writer.ToString();
           
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, localSuppliers, namespaces);

            return writer.ToString();
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithTheirListOfPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    PartsForCar = c.PartsCars
                                   .OrderByDescending(c => c.Part.Price)
                                   .Select(p => new ExportListPartsForCar()
                                   {
                                       Name = p.Part.Name,
                                       Price = p.Part.Price
                                   })
                                   .ToArray()

                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsWithTheirListOfPartsDto[]), new XmlRootAttribute("cars"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, carsWithTheirParts, namespaces);

            return writer.ToString();
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => new
                    {
                        Price = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                       : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    })
                    .ToArray()  
                })
                .ToArray();

            var customersDto = customers
               .OrderByDescending(c => c.SpentMoney.Sum(s => s.Price))
               .Select(c => new ExportCustomerTotalSales
               {
                   Name = c.Name,
                   BoughtCars = c.BoughtCars,
                   SpentMoney = c.SpentMoney.Sum(s => s.Price).ToString("f2")
               })
               .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerTotalSales[]), new XmlRootAttribute("customers"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, customersDto, namespaces);

            return writer.ToString();
        }

        //Problem 19 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context
                .Sales
                .Include(s => s.Car)
                .ThenInclude(c => c.PartsCars)
                .ThenInclude(pc => pc.Part)
                .Select(s => new ExportSaleWithAppliedDiscountDto
                {
                    Car = new ExportCarWithSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("f2"),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars
                    .Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                    .ToString()
                })
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);
            var serializer = new XmlSerializer(typeof(ExportSaleWithAppliedDiscountDto[]), new XmlRootAttribute("sales"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, salesWithDiscount, namespaces);

            return writer.ToString();
        }
    }
}