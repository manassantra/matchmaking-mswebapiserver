using Microsoft.EntityFrameworkCore;
using mswebapiserver.Models;
using mswebapiserver.Models.User;

namespace mswebapiserver.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AgentUser> AgentUsers { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<UserGallery> ImageGallery { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<UserFeed> UserFeeds { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserMatch> UserMatches { get; set; }
        public DbSet<UserJobDetail> UserJobDetails { get; set; }
        public DbSet<UserEducationDetail> UserEducationDetails { get; set; }
        public DbSet<PersonalDetail>  UserPersonalDetails { get; set; }
        public DbSet<FamilyDetail> UserFamilyDetails { get; set; }
        public DbSet<UserReligion> UserReligions { get; set; }
        public DbSet<PartnerPreferance> PartnerPreferances { get; set; }

    }
}
