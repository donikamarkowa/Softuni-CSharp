namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDto[]), new XmlRootAttribute("Countries"));
            StringReader stringReader = new StringReader(xmlString);
            ImportCountryDto[] countriesDto = (ImportCountryDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Country> countries = new List<Country>();
            foreach (var countryDto in countriesDto)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                countries.Add(new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                });

                sb.AppendLine(string.Format(SuccessfulImportCountry, countryDto.CountryName, countryDto.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString();

        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), new XmlRootAttribute("Manufacturers"));
            StringReader reader = new StringReader(xmlString);
            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto) || manufacturers.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;   
                }

                manufacturers.Add(new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                });

                string[] foundedSplit = manufacturerDto.Founded.Split(", ");
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturerDto.ManufacturerName, $"{foundedSplit[foundedSplit.Length - 2]}, {foundedSplit[foundedSplit.Length - 1]}"));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportShellDto[]), new XmlRootAttribute("Shells"));
            StringReader reader = new StringReader(xmlString);
            ImportShellDto[] shellDtos = (ImportShellDto[])serializer.Deserialize(reader);  

            ICollection<Shell> shells = new List<Shell>();
            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;   
                }

                shells.Add(new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                });

                sb.AppendLine(string.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));    
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            ICollection<Gun> guns = new HashSet<Gun>();

            foreach (var gunDto in gunDtos)
            {
                bool isGunTypeValid = Enum.TryParse<GunType>(gunDto.GunType, out GunType validGunType);

                if (!IsValid(gunDto) || !isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    BarrelLength = gunDto.BarrelLength,
                    GunType = validGunType,
                    GunWeight = gunDto.GunWeight,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    ShellId = gunDto.ShellId,
                    ManufacturerId = gunDto.ManufacturerId
                };

                foreach (var countryDto in gunDto.countryIdDto)
                {
                    gun.CountriesGuns.Add(new CountryGun()
                    {
                        CountryId = countryDto.Id,
                        Gun = gun
                    });
                }
                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, validGunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}