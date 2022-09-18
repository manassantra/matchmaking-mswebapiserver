using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class UserJobDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userRefId { get; set; }
        public string? JobTitle { get; set; }
        public string? JobType { get; set; }
        public string? companyName { get; set; }
        public string? salaryDetails { get; set; }
        public string? jobLocation { get; set; }
        public DateTime jobStartDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
        public bool? isDeleted { get; set; }

    }
}
