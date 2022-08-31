using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models
{
    public class ApplicationRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? roleName { get; set; }
        public string? Description { get; set; }
        public bool isActive { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }

    }
}
