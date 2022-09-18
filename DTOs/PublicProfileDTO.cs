using mswebapiserver.Models.User;

namespace mswebapiserver.DTOs
{
    public class PublicProfileDTO
    {
        public int userRefId { get; set; }
        public string? userName { get; set; }
        public string? image { get; set; }
        public bool isFollowed { get; set; }
    }
}
