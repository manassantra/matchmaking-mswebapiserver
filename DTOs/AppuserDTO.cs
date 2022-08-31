namespace mswebapiserver.DTOs
{
    public class AppuserDTO
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public Int64 mobile { get; set; }
        public string? password { get; set; }
        public string? gender { get; set; }
        public string? agentId { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
    }
}
