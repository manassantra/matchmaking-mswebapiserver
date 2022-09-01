using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models
{
    public class UserImagesGallery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? uid { get; set; }
        public string? imageUrl { get; set; }
        public string? imageDescription { get; set; }
        public DateTime createdDate { get; set; }
        public string? createdBy { get; set; }
    }
}
