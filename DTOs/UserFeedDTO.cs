namespace mswebapiserver.DTOs
{
    public class UserFeedDTO
    {
        public int userRefId { get; set; }
        public string? postDescription { get; set; }
        public DateTime? createdAt { get; set; }
        public string? createdBy { get; set; }
    }
}
