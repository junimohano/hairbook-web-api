using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HairbookWebApi.Database;
using HairbookWebApi.Models;

namespace HairbookWebApi.Migrations
{
    [DbContext(typeof(HairbookContext))]
    partial class HairbookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HairbookWebApi.Models.Memo", b =>
                {
                    b.Property<int>("MemoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessType");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 965, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("SalonId");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("MemoId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SalonId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Memo");
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoEvaluation", b =>
                {
                    b.Property<int>("MemoEvaluationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("EvaluationType");

                    b.Property<int>("MemoId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UserId");

                    b.HasKey("MemoEvaluationId");

                    b.HasAlternateKey("UserId", "MemoId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("MemoId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("MemoEvaluation");
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoTag", b =>
                {
                    b.Property<int>("MemoTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("MemoId");

                    b.Property<string>("TagName");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UserId");

                    b.HasKey("MemoTagId");

                    b.HasAlternateKey("UserId", "MemoId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("MemoId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("MemoTag");
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoUpload", b =>
                {
                    b.Property<int>("MemoUploadId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<int>("MemoId");

                    b.Property<string>("Path");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UploadType");

                    b.HasKey("MemoUploadId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("MemoId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("MemoUpload");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessType");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("SalonId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.HasKey("PostId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SalonId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostEvaluation", b =>
                {
                    b.Property<int>("PostEvaluationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("EvaluationType");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UserId");

                    b.HasKey("PostEvaluationId");

                    b.HasAlternateKey("UserId", "PostId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostEvaluation");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostTag", b =>
                {
                    b.Property<int>("PostTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 974, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("PostId");

                    b.Property<string>("TagName");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UserId");

                    b.HasKey("PostTagId");

                    b.HasAlternateKey("UserId", "PostId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostUpload", b =>
                {
                    b.Property<int>("PostUploadId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Path");

                    b.Property<int>("PostId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UploadType");

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

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

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

            modelBuilder.Entity("HairbookWebApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int?>("SalonId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<string>("UserKey")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasAlternateKey("UserKey");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SalonId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HairbookWebApi.Models.UserFriend", b =>
                {
                    b.Property<int>("UserFriendId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 5, 31, 23, 1, 46, 975, DateTimeKind.Local));

                    b.Property<int?>("CreatedUserId");

                    b.Property<int>("FriendId");

                    b.Property<bool>("IsPending");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<int>("UserId");

                    b.HasKey("UserFriendId");

                    b.HasAlternateKey("UserId", "FriendId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("FriendId");

                    b.HasIndex("UpdatedUserId");

                    b.ToTable("UserFriend");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Memo", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoEvaluation", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Memo", "Memo")
                        .WithMany("Evaluations")
                        .HasForeignKey("MemoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "User")
                        .WithMany("MemoEvaluations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoTag", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Memo", "Memo")
                        .WithMany("Tags")
                        .HasForeignKey("MemoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "User")
                        .WithMany("MemoTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairbookWebApi.Models.MemoUpload", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Memo", "Memo")
                        .WithMany("Uploads")
                        .HasForeignKey("MemoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");
                });

            modelBuilder.Entity("HairbookWebApi.Models.Post", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId")
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
                        .WithMany("Evaluations")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "User")
                        .WithMany("PostEvaluations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostTag", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "User")
                        .WithMany("PostTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairbookWebApi.Models.PostUpload", b =>
                {
                    b.HasOne("HairbookWebApi.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("HairbookWebApi.Models.Post", "Post")
                        .WithMany("Uploads")
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
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("HairbookWebApi.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId");

                    b.HasOne("HairbookWebApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
