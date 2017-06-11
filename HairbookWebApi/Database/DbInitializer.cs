using HairbookWebApi.Models;
using System;
using System.Linq;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Database
{
    public class DbInitializer
    {
        public static void Initialize(HairbookContext context)
        {
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new[]
            {
                new User{UserKey= "11111111", CreatedDate= DateTime.Now, },
                new User{UserKey= "222222222", CreatedDate= DateTime.Now, },
                new User{UserKey= "333333333", CreatedDate= DateTime.Now, },
                new User{UserKey= "4444444", CreatedDate= DateTime.Now, },
                new User{UserKey= "5555555", CreatedDate= DateTime.Now, },
                new User{UserKey= "666666", CreatedDate= DateTime.Now, }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var hairMenus = new[]
            {
                new HairMenu(){ Name = "Cut" },
                new HairMenu(){ Name = "Color" },
                new HairMenu(){ Name = "Parm" },
                new HairMenu(){ Name = "Wb" },
                new HairMenu(){ Name = "Updo" }
            };
            context.HairMenus.AddRange(hairMenus);
            context.SaveChanges();

            var hairSubMenus = new[]
            {
                new HairSubMenu(){ Name = "Full Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Digital Parm", HairMenuId = 3}
            };
            context.HairSubMenus.AddRange(hairSubMenus);
            context.SaveChanges();

            var hairTypes = new[]
            {
                new HairType(){ Name = "Thin" },
                new HairType(){ Name = "Thick" },
                new HairType(){ Name = "Colored" },
                new HairType(){ Name = "Bleached" },
                new HairType(){ Name = "Parmed" },
                new HairType(){ Name = "Straight" },
                new HairType(){ Name = "Wavy" },
                new HairType(){ Name = "Fleezy" }
            };
            context.HairTypes.AddRange(hairTypes);
            context.SaveChanges();

            var customers = new[]
            {
                new Customer(){ Name = "Jonh Park", Gender = GenderType.Male, UserId = 1},
                new Customer(){ Name = "Jenny", Gender = GenderType.Male, UserId = 1},
                new Customer(){ Name = "Mark Jang", Gender = GenderType.Male, UserId = 1},
                new Customer(){ Name = "Petric San", Gender = GenderType.Male, UserId = 1},
                new Customer(){ Name = "Totoro", Gender = GenderType.Male, UserId = 1}
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var salons = new[]
            {
                new Salon(){ Name = "NC Salon", Address = "11 Finch"},
                new Salon(){ Name = "ABC Salon", Address = "16 Harrison garden"}
            };
            context.Salons.AddRange(salons);
            context.SaveChanges();

            var tags = new[]
            {
                new Tag(){ TagName = "Tag1" },
                new Tag(){ TagName = "Tag2" },
                new Tag(){ TagName = "Tag3" },
                new Tag(){ TagName = "Tag4" },
                new Tag(){ TagName = "Tag5" },
                new Tag(){ TagName = "Tag6" },
                new Tag(){ TagName = "Tag7" },
                new Tag(){ TagName = "Tag8" },
                new Tag(){ TagName = "Tag9" },
                new Tag(){ TagName = "Tag10" },
            };
            context.Tags.AddRange(tags);
            context.SaveChanges();

            var posts = new[]
            {
                new Post(){ CustomerId = 1, Date = DateTime.Now, Memo = "Test1", SalonId = 1, HairTypeId = 1, HairMemo = "too thin", AccessType = AccessType.Public },
                new Post(){ CustomerId = 2, Date = DateTime.Now, Memo = "Test2", SalonId = 2, HairTypeId = 2, HairMemo = "Memo 2", AccessType = AccessType.Private },
                new Post(){ CustomerId = 3, Date = DateTime.Now, Memo = "Test3", SalonId = 1, HairTypeId = 3, HairMemo = "Memo 3", AccessType = AccessType.OnlyFriends },
                new Post(){ CustomerId = 4, Date = DateTime.Now, Memo = "Test4", SalonId = 2, HairTypeId = 4, HairMemo = "Memo 4", AccessType = AccessType.Public },
                new Post(){ CustomerId = 5, Date = DateTime.Now, Memo = "Test4", SalonId = 2, HairTypeId = 4, HairMemo = "Memo 5", AccessType = AccessType.Public },
                new Post(){ CustomerId = 1, Date = DateTime.Now, Memo = "Test5", SalonId = 1, HairTypeId = 6, HairMemo = "Memo 6", AccessType = AccessType.Public },
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();

            var postComments = new[]
            {
                new PostComment(){ PostId = 1, UserId = 1, Comment= "Test1" },
                new PostComment(){ PostId = 1, UserId = 1, Comment= "Test2" },
                new PostComment(){ PostId = 1, UserId = 1, Comment= "Test3" },
                new PostComment(){ PostId = 2, UserId = 1, Comment= "Test4" },
                new PostComment(){ PostId = 3, UserId = 1, Comment= "Test5" },
                new PostComment(){ PostId = 4, UserId = 1, Comment= "Test6" },
                new PostComment(){ PostId = 5, UserId = 1, Comment= "Test7" },
            };
            context.PostComments.AddRange(postComments);
            context.SaveChanges();

            var postCommentTags = new[]
        {
                new PostCommentTag(){ PostCommentId = 1, UserId = 1, TagId = 1},
                new PostCommentTag(){ PostCommentId = 2, UserId = 1, TagId = 2},
                new PostCommentTag(){ PostCommentId = 3, UserId = 1, TagId = 3},
                new PostCommentTag(){ PostCommentId = 4, UserId = 4, TagId = 4},
                new PostCommentTag(){ PostCommentId = 5, UserId = 1, TagId = 5},
                new PostCommentTag(){ PostCommentId = 6, UserId = 1, TagId = 6},
                new PostCommentTag(){ PostCommentId = 7, UserId = 1, TagId = 7},
                new PostCommentTag(){ PostCommentId = 1, UserId = 2, TagId = 8},
                new PostCommentTag(){ PostCommentId = 1, UserId = 3, TagId = 9},
            };
            context.PostCommentTags.AddRange(postCommentTags);
            context.SaveChanges();

            var postEvaluations = new[]
            {
                new PostEvaluation(){ PostId = 1, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 1, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 1, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 2, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 3, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 4, UserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 5, UserId = 1, EvaluationType= EvaluationType.Like },
            };
            context.PostEvaluations.AddRange(postEvaluations);
            context.SaveChanges();

            var postHairMenus = new[]
            {
                new PostHairMenu(){ PostId = 1, HairMenuId = 1, Memo = "hairmenu test1"},
                new PostHairMenu(){ PostId = 1, HairMenuId = 2, HairSubMenuId = 1, Memo = "hairmenu test2"},
                new PostHairMenu(){ PostId = 1, HairMenuId = 3, HairSubMenuId = 1, Memo = "hairmenu test3"},
                new PostHairMenu(){ PostId = 2, HairMenuId = 1, Memo = "hairmenu test4"},
                new PostHairMenu(){ PostId = 3, HairMenuId = 1, Memo = "hairmenu test5"},
                new PostHairMenu(){ PostId = 4, HairMenuId = 1, Memo = "hairmenu test6"},
                new PostHairMenu(){ PostId = 5, HairMenuId = 1, Memo = "hairmenu test7"},
            };
            context.PostHairMenus.AddRange(postHairMenus);
            context.SaveChanges();

            var postHairTypes = new[]
            {
                new PostHairType(){ PostId = 1, HairTypeId = 1 },
                new PostHairType(){ PostId = 1, HairTypeId = 3 },
                new PostHairType(){ PostId = 1, HairTypeId = 4 },
                new PostHairType(){ PostId = 2, HairTypeId = 1 },
                new PostHairType(){ PostId = 3, HairTypeId = 1 },
                new PostHairType(){ PostId = 4, HairTypeId = 1 },
                new PostHairType(){ PostId = 5, HairTypeId = 1 },
            };
            context.PostHairTypes.AddRange(postHairTypes);
            context.SaveChanges();

            var postUploads = new[]
            {
                new PostUpload(){ PostId = 1, Memo = "Picture 1", Path = @"\uploads\636324634446580830_5dc3bd98b4482e93ee99c7d54d7bcff8.jpg", UploadCategoryType  = UploadCategoryType.Before, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 1, Memo = "Picture 2", Path = @"\uploads\636324634521366194_a970d88c0f6d3134f84e99427fcb0ca4.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 1, Memo = "Picture 3", Path = @"\uploads\636324634734101147_Quick-Last-minute-Hairstyles-For-Working-Women0041-1.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 1, Memo = "Picture 4", Path = @"\uploads\636324635695961081_989b4fd57f9c9b80cce80c457da0ae1c.jpg", UploadCategoryType  = UploadCategoryType.RoleModel, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 2, Memo = "Picture 5", Path = @"\uploads\636324635749501488_cd264af1dda2815467b6e55ee51657aa.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 3, Memo = "Picture 6", Path = @"\uploads\636324232546772032_3c7d3bb65e1a6e2a34a3faed5a665f1d.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 4, Memo = "Picture 7", Path = @"\uploads\636324232474535016_download.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
                new PostUpload(){ PostId = 5, Memo = "Picture 8", Path = @"\uploads\636324634446580830_5dc3bd98b4482e93ee99c7d54d7bcff8.jpg", UploadCategoryType  = UploadCategoryType.After, UploadFileType = UploadFileType.Image },
            };
            context.PostUploads.AddRange(postUploads);
            context.SaveChanges();
          
        }
    }
}

