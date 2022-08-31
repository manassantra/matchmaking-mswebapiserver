namespace mswebapiserver.DTOs
{
    public class ApplicationRoleDTO
    {
        public string? roleName { get; set; }
        public string? Description { get; set; }
        public string? accessGroup { get; set; }
        public DateTime createdAt { get; set; }
        public string? createdBy { get; set; }
        public bool isActive { get; set; }
    }
}
