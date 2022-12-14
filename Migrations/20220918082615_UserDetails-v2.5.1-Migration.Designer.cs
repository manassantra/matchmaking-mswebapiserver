// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mswebapiserver.Data;

#nullable disable

namespace mswebapiserver.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220918082615_UserDetails-v2.5.1-Migration")]
    partial class UserDetailsv251Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("mswebapiserver.Models.AddressDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AddressDetails");
                });

            modelBuilder.Entity("mswebapiserver.Models.AdminUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("mswebapiserver.Models.AgentUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("agent_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("AgentUsers");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.AppUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("agentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("isMobileVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("isPremium")
                        .HasColumnType("bit");

                    b.Property<bool>("isPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.FamilyDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("familyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fathersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("mothersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nativePlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfBrothers")
                        .HasColumnType("int");

                    b.Property<int>("noOfSisters")
                        .HasColumnType("int");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserFamilyDetails");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.PartnerPreferance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ageFrom")
                        .HasColumnType("int");

                    b.Property<int>("ageTo")
                        .HasColumnType("int");

                    b.Property<string>("area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("canSpeak")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("community")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gothra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("highetFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("highetTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isPremium")
                        .HasColumnType("bit");

                    b.Property<string>("jobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("motherToung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subCommunity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PartnerPreferances");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.PersonalDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("bloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("canSpeak")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("grewUpLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("maritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("motherToung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sunSign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserPersonalDetails");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.ProfilePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("imageFilename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("userRefid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserEducationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("heighestQualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instituteLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instituteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("passOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserEducationDetails");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserFeed", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("postBatchId")
                        .HasColumnType("int");

                    b.Property<string>("postDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("UserFeeds");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserFollower", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("followedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("followedUserId")
                        .HasColumnType("int");

                    b.Property<bool?>("isFollowing")
                        .HasColumnType("bit");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("UserFollowers");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("UserFeedid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("imageFilename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("postBatchId")
                        .HasColumnType("int");

                    b.Property<int>("userRefid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserFeedid");

                    b.ToTable("ImageGallery");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserJobDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("jobLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("jobStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("salaryDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserJobDetails");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("agentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isMatched")
                        .HasColumnType("bit");

                    b.Property<bool>("isMatchedSuccessfull")
                        .HasColumnType("bit");

                    b.Property<string>("matchRequestby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user1Id")
                        .HasColumnType("int");

                    b.Property<string>("user1Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user1Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user2Id")
                        .HasColumnType("int");

                    b.Property<string>("user2Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user2Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserMatches");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserReligion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("community")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gothra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subCommunity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRefId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("UserReligions");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserGallery", b =>
                {
                    b.HasOne("mswebapiserver.Models.User.UserFeed", null)
                        .WithMany("imageDetails")
                        .HasForeignKey("UserFeedid");
                });

            modelBuilder.Entity("mswebapiserver.Models.User.UserFeed", b =>
                {
                    b.Navigation("imageDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
