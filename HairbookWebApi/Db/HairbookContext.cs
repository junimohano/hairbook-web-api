using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Swashbuckle.Swagger.Model;

namespace HairbookWebApi.Db
{
    public class HairbookContext : DbContext
    {
        public HairbookContext(DbContextOptions<HairbookContext> options) : base(options) { }

        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<PostEvaluation> PostEvaluations { get; set; }
        public DbSet<MemoEvaluation> MemoEvaluations { get; set; }
        public DbSet<EvaluationType> EvaluationTypes { get; set; }
        public DbSet<Memo> Memos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<MemoTag> MemoTags { get; set; }
        public DbSet<PostUpload> PostUploads { get; set; }
        public DbSet<MemoUpload> MemoUploads { get; set; }
        public DbSet<UploadType> UploadTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");

            //unique
            modelBuilder.Entity<User>().HasAlternateKey(c => c.UserKey);
            modelBuilder.Entity<UserFriend>().HasAlternateKey(x => new { x.UserId, x.FriendId });
            modelBuilder.Entity<PostEvaluation>().HasAlternateKey(x => new { x.UserId, x.PostId });
            modelBuilder.Entity<MemoEvaluation>().HasAlternateKey(x => new { x.UserId, x.MemoId });
            modelBuilder.Entity<PostTag>().HasAlternateKey(x => new { x.UserId, x.PostId });
            modelBuilder.Entity<MemoTag>().HasAlternateKey(x => new { x.UserId, x.MemoId });

            // one to many
            modelBuilder.Entity<AccessType>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AccessType>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemoEvaluation>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MemoEvaluation>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvaluationType>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EvaluationType>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Memo>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Memo>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Salon>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Salon>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostTag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostTag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemoTag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MemoTag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostUpload>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostUpload>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemoUpload>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MemoUpload>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UploadType>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UploadType>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany().OnDelete(DeleteBehavior.Restrict);

            // many to many
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.User).WithMany(y => y.PostEvaluations).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.Post).WithMany(y => y.Evaluations).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<MemoEvaluation>().HasOne(x => x.User).WithMany(y => y.MemoEvaluations).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MemoEvaluation>().HasOne(x => x.Memo).WithMany(y => y.Evaluations).HasForeignKey(z => z.MemoId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PostTag>().HasOne(x => x.User).WithMany(y => y.PostTags).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostTag>().HasOne(x => x.Post).WithMany(y => y.Tags).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<MemoTag>().HasOne(x => x.User).WithMany(y => y.MemoTags).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MemoTag>().HasOne(x => x.Memo).WithMany(y => y.Tags).HasForeignKey(z => z.MemoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
