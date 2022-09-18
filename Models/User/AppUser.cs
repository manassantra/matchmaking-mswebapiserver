using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mswebapiserver.Models.User
{
    public class AppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? uid { get; set; }

        [Required]
        public string? firstName { get; set; }

        [Required]
        public string? lastName { get; set; }
        public string? fullName { get; set; }

        [Required]
        public string? email { get; set; }
        public bool isEmailVerified { get; set; }

        [Required]
        public long mobile { get; set; }
        public bool isMobileVerified { get; set; }

        [JsonIgnore]
        public byte[]? passwordHash { get; set; }

        [JsonIgnore]
        public byte[]? passwordSalt { get; set; }

        public string? gender { get; set; }

        public string? agentId { get; set; }

        public bool isActive { get; set; }

        public bool isPremium { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime modifiedDate { get; set; }

        public string? modifiedBy { get; set; }

        public bool isPrivate { get; set; }
    }
}
