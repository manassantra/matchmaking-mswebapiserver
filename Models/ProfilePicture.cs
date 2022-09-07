using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models
{
    public class ProfilePicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? imageFilename { get; set; }
        public int userRefid { get; set; }
        public string? imagePath { get; set; }
        public DateTime? createdDate { get; set; }
        public string? createdBy { get; set; }
        public bool? isDeleted { get; set; }
    }
}
