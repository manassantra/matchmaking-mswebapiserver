using System.Collections;

namespace mswebapiserver.Models
{
    public class UserFeed
    {
        public int id { get; set; }
        public int userRefId { get; set; }
        public string? postDescription { get; set; }
        public int postBatchId { get; set; }

        public List<UserGallery> imageDetails { get; set; }
        public DateTime? createdAt { get; set; }
        public string? createdBy { get; set; }
        public bool? isDeleted { get; set; }
    }
}
