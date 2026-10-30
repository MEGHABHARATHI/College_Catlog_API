using System.ComponentModel.DataAnnotations;

namespace CollegeCatalog.API.DTOs
{
    public class CollegeDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string University { get; set; } = string.Empty;

        public int NumberOfStudent { get; set; } = 0;

    }
}