namespace mswebapiserver.DTOs
{
    public class AdminuserRegisterDTO
    {
        public int roleId { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdAt { get; set; }
        public bool? isActive { get; set; }
    }
}
