namespace mswebapiserver.Models.User
{
    public class UserMatch
    {
        public int Id { get; set; }
        public int user1Id { get; set; }
        public string? user1Name { get; set; }
        public string? user1Image { get; set; }
        public int user2Id { get; set; }
        public string? user2Name { get; set; }
        public string? user2Image { get; set; }
        public int agentId { get; set; }
        public bool isMatchedSuccessfull { get; set; }
        public bool isMatched { get; set; }
        public DateTime createdAt { get; set; }
        public string? matchRequestby { get; set; }
        public bool isActive { get; set; }

    }
}
