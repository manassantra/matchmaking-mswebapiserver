using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class UserEducationDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userRefId { get; set; }

        [Required]
        public string? heighestQualification { get; set; }

        [Required]
        public string? instituteName { get; set; }

        [Required]
        public string? instituteLocation { get; set; }

        [Required]
        public DateTime passOutDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
        public bool isActive { get; set; }

    }
}
