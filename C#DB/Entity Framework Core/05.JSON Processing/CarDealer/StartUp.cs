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

            string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string result = ImportSuppliers(dbContext, inputJson);
            Console.WriteLine(result);
        }
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
    }
}