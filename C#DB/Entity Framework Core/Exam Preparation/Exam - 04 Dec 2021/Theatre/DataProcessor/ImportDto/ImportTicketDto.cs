using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTicketDto
    {
        [JsonProperty("Price")]
        [Required]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }
        [JsonProperty("RowNumber")]
        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }
        [JsonProperty("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
