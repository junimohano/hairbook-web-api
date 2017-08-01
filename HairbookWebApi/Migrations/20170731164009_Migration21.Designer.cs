using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HairbookWebApi.Database;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Migrations
{
    [DbContext(typeof(HairbookContext))]
    [Migration("20170731164009_Migration21")]
    partial class Migration21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HairbookWebApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDay");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("CustomerId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("HairbookWebApi.Models.HairMenu", b =>
                {
                    b.Property<int>("HairMenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("HairMenuId");

                    b.ToTable("HairMenu");
                });

            modelBuilder.Entity("HairbookWebApi.Models.HairSubMenu", b =>
                {
                    b.Property<int>("HairSubMenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HairMenuId");

                    b.Property<string>("Name");

                    b.HasKey("HairSubMenuId");

                    b.HasIndex("HairMenuId");

                    b.ToTable("HairSubMenu");
                });

            modelBuilder.Entity("HairbookWebApi.Models.HairType", b =>
                {
                    b.Property<int>("HairTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("HairTypeId");

                    b.ToTable("HairType");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessType");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("HairTypeMemo");

                    b.Property<string>("Memo");

                    b.Property<int?>("SalonId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalonId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostComment", b =>
                {
                    b.Property<int>("PostCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostCommentId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostComment");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostCommentTag", b =>
                {
                    b.Property<int>("PostCommentTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("PostCommentId");

                    b.Property<int>("TagId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostCommentTagId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostCommentId");

                    b.HasIndex("TagId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostCommentTag");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostEvaluation", b =>
                {
                    b.Property<int>("PostEvaluationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId")
                        .IsRequired();

                    b.Property<int>("EvaluationType");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostEvaluationId");

                    b.HasAlternateKey("PostId", "CreatedUserId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostEvaluation");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostFavorite", b =>
                {
                    b.Property<int>("PostFavoriteId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId")
                        .IsRequired();

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostFavoriteId");

                    b.HasAlternateKey("PostId", "CreatedUserId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostFavorite");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostHairMenu", b =>
                {
                    b.Property<int>("PostHairMenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<byte[]>("Drawing");

                    b.Property<int>("HairMenuId");

                    b.Property<int?>("HairSubMenuId");

                    b.Property<string>("Memo");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostHairMenuId");

                    b.HasAlternateKey("PostId", "PostHairMenuId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("HairMenuId");

                    b.HasIndex("HairSubMenuId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostHairMenu");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostHairType", b =>
                {
                    b.Property<int>("PostHairTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("HairTypeId");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostHairTypeId");

                    b.HasAlternateKey("PostId", "PostHairTypeId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("HairTypeId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostHairType");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostUpload", b =>
                {
                    b.Property<int>("PostUploadId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("Memo");

                    b.Property<string>("Path");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UploadCategoryType");

                    b.Property<int>("UploadFileType");

                    b.HasKey("PostUploadId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostUpload");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<string>("Url");

                    b.HasKey("SalonId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<int?>("PostCommentId");

                    b.Property<string>("TagName");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("TagId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostCommentId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("HairbookWebApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Provider");

                    b.Property<int?>("SalonId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<string>("UserKey");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasAlternateKey("UserName");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SalonId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HairbookWebApi.Models.UserFriend", b =>
                {
                    b.Property<int>("UserFriendId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId")
                        .IsRequired();

                    b.Property<int>("FriendId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("UserFriendId");

                    b.HasAlternateKey("FriendId", "CreatedUserId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("UserFriend");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Customer", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.HairSubMenu", b =>
                {
                    b.HasOne("HairbookWebApi.Models.HairMenu", "HairMenu")
                        .WithMany("HairSubMenus")
                        .HasForeignKey("HairMenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairbookWebApi.Models.Post", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostComment", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostCommentTag", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.PostComment", "PostComment")
                        .WithMany()
                        .HasForeignKey("PostCommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostEvaluation", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostEvaluations")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostFavorite", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany("PostFavorites")
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostFavorites")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostHairMenu", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.HairMenu", "HairMenu")
                        .WithMany()
                        .HasForeignKey("HairMenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.HairSubMenu", "HairSubMenu")
                        .WithMany()
                        .HasForeignKey("HairSubMenuId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostHairMenus")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostHairType", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.HairType", "HairType")
                        .WithMany()
                        .HasForeignKey("HairTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostHairTypes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostUpload", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("PostUploads")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Salon", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Tag", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.PostComment")
                        .WithMany("Tags")
                        .HasForeignKey("PostCommentId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.User", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.UserFriend", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "Friend")
                        .WithMany("UserFriends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });
        }
    }
}
