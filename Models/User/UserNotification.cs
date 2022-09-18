using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models.User
{
    public class UserNotification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Notification { get; set; }
        public int userId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
