using System.ComponentModel.DataAnnotations;

namespace mswebapiserver.DTOs
{
    public class EducationalDetailsDTO
    {
        [Required]
        public string? heighestQualification { get; set; }

        [Required]
        public string? instituteName { get; set; }

        [Required]
        public string? instituteLocation { get; set; }

        [Required]
        public DateTime passOutDate { get; set; }
    }
}
