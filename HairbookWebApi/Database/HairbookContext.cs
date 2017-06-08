using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace HairbookWebApi.Database
{
    public class HairbookContext : DbContext
    {
        public HairbookContext(DbContextOptions<HairbookContext> options) : base(options) { }
        
        public DbSet<PostEvaluation> PostEvaluations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostUpload> PostUploads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");

            //unique
            modelBuilder.Entity<User>().HasAlternateKey(c => c.UserKey);
            modelBuilder.Entity<UserFriend>().HasAlternateKey(x => new { x.UserId, x.FriendId });
            modelBuilder.Entity<PostTag>().HasAlternateKey(x => new { x.PostId, x.TagId });

            // one to many
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Salon>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Salon>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostTag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostTag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostUpload>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostUpload>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany().OnDelete(DeleteBehavior.Restrict);

            // many to many
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.Post).WithMany(y => y.Evaluations).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>().HasOne(x => x.Tag).WithMany(y => y.PostTags).HasForeignKey(z => z.TagId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostTag>().HasOne(x => x.Post).WithMany(y => y.Tags).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);

            // default value
            //modelBuilder.Entity<Memo>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<MemoEvaluation>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<MemoTag>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<MemoUpload>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<Post>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<PostEvaluation>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<PostTag>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<PostUpload>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<Salon>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<Tag>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<User>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<UserFriend>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
