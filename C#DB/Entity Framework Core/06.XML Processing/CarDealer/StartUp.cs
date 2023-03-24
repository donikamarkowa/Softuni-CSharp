using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
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

            string result = GetCarsWithDistance(context);
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
    }
}