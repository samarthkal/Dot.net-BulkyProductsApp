using System.ComponentModel.DataAnnotations;

namespace BulkyRazorApps.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "invalid")]
        public string Name { get; set; } = "";
        [Required]
        [Range(1, 100, ErrorMessage = "not valid")]
        public int DisplayOrder { get; set; }

    }
}
