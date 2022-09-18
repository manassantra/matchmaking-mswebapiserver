using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class PersonalDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userRefId { get; set; }
        public string? maritalStatus { get; set; }
        public string? sunSign { get; set; }
        public string? canSpeak { get; set; }
        public string? motherToung { get; set; }
        public string? bloodGroup { get; set; }
        public string? height { get; set; }
        public int age { get; set; }
        public DateTime dob { get; set; }   
        public string? dite { get; set; }
        public string? grewUpLocation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? modifiedBy { get; set; }
        public bool isActive { get; set; }
    }
}
