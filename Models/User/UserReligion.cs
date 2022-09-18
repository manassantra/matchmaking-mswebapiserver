using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class UserReligion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int userRefId { get; set; }
        public string? religion { get; set; }
        public string? community { get; set; }
        public string? subCommunity { get; set; }
        public string? gothra { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
        public bool isActive { get; set; }
    }
}
