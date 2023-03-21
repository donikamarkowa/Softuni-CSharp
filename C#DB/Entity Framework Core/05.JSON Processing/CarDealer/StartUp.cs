using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(dbContext, inputJson);

            string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            string result = ImportParts(dbContext, inputJson);
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
                if(!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
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
    }
}