using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportEmployeeDto
    {
        [JsonProperty("Username")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"[A-Za-z0-9]+")]
        public string Username { get; set; } = null!;

        [JsonProperty("Email")]
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string Email { get; set; } = null!;

        [JsonProperty("Phone")]
        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}")]
        public string Phone { get; set; } = null!;

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; } = null!;
    }
}
