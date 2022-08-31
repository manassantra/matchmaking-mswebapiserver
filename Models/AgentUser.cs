using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mswebapiserver.Models
{
    public class AgentUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? agent_id { get; set; }

        [Required]
        public string? firstName { get; set; }

        [Required]
        public string? lastName { get; set; }

        public string? fullName { get; set; }

        [Required]
        public string? email { get; set; }

        [Required]
        public Int64 mobile { get; set; }

        [JsonIgnore]
        public byte[]? passwordHash { get; set; }

        [JsonIgnore]
        public byte[]? passwordSalt { get; set; }

        public string? gender { get; set; }

        public bool isActive { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime modifiedDate { get; set; }

        public string? modifiedBy { get; set; }
    }
}
