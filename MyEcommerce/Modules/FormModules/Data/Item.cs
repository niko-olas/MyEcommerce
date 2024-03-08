using System.ComponentModel.DataAnnotations;

namespace FormModules.Data
{
    public class Item
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(10)]
        public string Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
