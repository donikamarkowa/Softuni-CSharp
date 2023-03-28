namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), new XmlRootAttribute("Coaches"));
            StringReader reader = new StringReader(xmlString);
            ImportCoachDto[] coachesDto = (ImportCoachDto[])serializer.Deserialize(reader);

            ICollection<Coach> coaches = new HashSet<Coach>();
            foreach (var coachDto in coachesDto)
            {
                if(!IsValid(coachDto) || string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                List<Footballer> footballers = new List<Footballer>();

                foreach (var footballerDto in coachDto.FootballerDtos)
                {
                    DateTime validStartDate;
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,
                                                                    "dd/MM/yyyy",
                                                                    CultureInfo.InvariantCulture,
                                                                    DateTimeStyles.None,
                                                                    out validStartDate);

                    DateTime validEndDate;
                    bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,
                                                            "dd/MM/yyyy",
                                                            CultureInfo.InvariantCulture,
                                                            DateTimeStyles.None,
                                                            out validEndDate);

                    if (!IsValid(footballerDto) || !isStartDateValid 
                        || !isEndDateValid || validStartDate > validEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType,
                        ContractStartDate = validStartDate,
                        ContractEndDate = validEndDate,
                        Coach = coach
                    };

                    footballers.Add(footballer);
                }
                coach.Footballers = footballers.ToArray();
                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, footballers.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var teamsDto = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> teams = new HashSet<Team>();
            foreach (var teamDto in teamsDto)
            {
                if (!IsValid(teamDto) || teamDto.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };
                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    Footballer footballer = context.Footballers.Find(footballerId);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFootballer = new TeamFootballer()
                    {
                        Footballer = footballer,
                        Team = team
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }
                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));

            }

            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
