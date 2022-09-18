using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class PartnerPreferance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userRefId { get; set; }
        public string? area { get; set; }
        public int ageFrom { get; set; }
        public int ageTo { get; set; }
        public string? maritalStatus { get; set; }
        public string? highetFrom { get; set; }
        public string? highetTo { get; set; }
        public string? religion { get; set; }
        public string? community { get; set; }
        public string? subCommunity { get; set; }
        public string? gothra { get; set; }
        public string? canSpeak { get; set; }
        public string? motherToung { get; set; }
        public string? jobType { get; set; }
        public bool? isPremium { get; set; }
        public DateTime modifiedOn { get; set; }
        public string? modifiedBy { get; set; }
    }
}
