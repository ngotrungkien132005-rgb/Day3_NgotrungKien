using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Day3_NgotrungKien.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string? Name { get; set;  }

        public string Description { get; set; }=string.Empty;
    }
}
