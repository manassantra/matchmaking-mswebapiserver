using System.ComponentModel.DataAnnotations.Schema;

namespace mswebapiserver.Models
{
    public class UserFollower
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime? followedDate { get; set; }
        public int ? followedUserId { get; set; }
        public bool? isFollowing { get; set; }

    }
}
