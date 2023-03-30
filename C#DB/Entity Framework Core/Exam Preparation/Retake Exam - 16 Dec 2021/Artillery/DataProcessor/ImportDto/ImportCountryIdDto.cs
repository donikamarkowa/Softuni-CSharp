using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCountryIdDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
