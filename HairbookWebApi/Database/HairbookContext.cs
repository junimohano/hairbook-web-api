using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HairbookWebApi.Database
{
    public class HairbookContext : DbContext
    {
        public HairbookContext(DbContextOptions<HairbookContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HairMenu> HairMenus { get; set; }
        public DbSet<HairSubMenu> HairSubMenus { get; set; }
        public DbSet<HairType> HairTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostEvaluation> PostEvaluations { get; set; }
        public DbSet<PostHairMenu> PostHairMenus { get; set; }
        public DbSet<PostHairType> PostHairTypes { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostCommentTag> PostCommentTags { get; set; }
        public DbSet<PostUpload> PostUploads { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");

            //unique
            modelBuilder.Entity<UserFriend>().HasAlternateKey(x => new { x.UserId, x.FriendId });
            modelBuilder.Entity<PostEvaluation>().HasAlternateKey(x => new { x.PostId, x.CreatedUserId });
            modelBuilder.Entity<PostHairMenu>().HasAlternateKey(x => new { x.PostId, x.PostHairMenuId });
            modelBuilder.Entity<PostHairType>().HasAlternateKey(x => new { x.PostId, x.PostHairTypeId });
            modelBuilder.Entity<User>().HasAlternateKey(x => new { x.UserName });

            // one to many
            modelBuilder.Entity<Customer>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostComment>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostComment>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostCommentTag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostCommentTag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostHairMenu>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostHairMenu>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostHairType>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostHairType>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostUpload>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostUpload>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Salon>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Salon>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tag>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tag>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostUpload>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostUpload>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.CreatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.UpdatedUser).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFriend>().HasOne(x => x.Friend).WithMany().OnDelete(DeleteBehavior.Restrict);

            // many to many
            modelBuilder.Entity<HairSubMenu>().HasOne(x => x.HairMenu).WithMany(y => y.HairSubMenus).HasForeignKey(z => z.HairMenuId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostHairMenu>().HasOne(x => x.Post).WithMany(y => y.PostHairMenus).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostHairType>().HasOne(x => x.Post).WithMany(y => y.PostHairTypes).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostEvaluation>().HasOne(x => x.Post).WithMany(y => y.PostEvaluations).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostComment>().HasOne(x => x.Post).WithMany(y => y.PostComments).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostUpload>().HasOne(x => x.Post).WithMany(y => y.PostUploads).HasForeignKey(z => z.PostId).OnDelete(DeleteBehavior.Cascade);

            // default value
            //modelBuilder.Entity<Memo>().Property(s => s.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
