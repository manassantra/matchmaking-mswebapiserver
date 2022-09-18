using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class FamilyDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userRefId { get; set; }
        public string? fathersName { get; set; }
        public string? mothersName { get; set; }
        public string? familyType { get; set; }
        public int noOfBrothers { get; set; }
        public int noOfSisters { get; set; }
        public string? nativePlace { get; set; }
        public string? location { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
        public bool isActive { get; set; }

    }
}
