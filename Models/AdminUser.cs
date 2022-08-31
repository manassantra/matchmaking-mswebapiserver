using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mswebapiserver.Models
{
    public class AdminUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int roleId { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }

        [JsonIgnore]
        public byte[]? passwordHash { get; set; }

        [JsonIgnore]
        public byte[]? passwordSalt { get; set; }

        public bool? isActive { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime modifiedDate { get; set; }

        public string? modifiedBy { get; set; }
    }
}
