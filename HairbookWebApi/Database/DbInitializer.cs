﻿using HairbookWebApi.Models;
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
                new User{UserKey= "11111111", CreatedDate= DateTime.Now, UserName = "a1" },
                new User{UserKey= "222222222", CreatedDate= DateTime.Now, UserName = "a2" },
                new User{UserKey= "333333333", CreatedDate= DateTime.Now, UserName = "a3" },
                new User{UserKey= "4444444", CreatedDate= DateTime.Now, UserName = "a4" },
                new User{UserKey= "5555555", CreatedDate= DateTime.Now, UserName = "a5" },
                new User{UserKey= "666666", CreatedDate= DateTime.Now, UserName = "a6" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var hairMenus = new[]
            {
                new HairMenu(){ Name = "Cut" },
                new HairMenu(){ Name = "Color" },
                new HairMenu(){ Name = "Perm" },
                new HairMenu(){ Name = "Wb" },
                new HairMenu(){ Name = "Updo" }
            };
            context.HairMenus.AddRange(hairMenus);
            context.SaveChanges();

            var hairSubMenus = new[]
            {
                new HairSubMenu(){ Name = "Root Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Full Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Balayage Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Highlights Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Partial Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Ombre Color", HairMenuId = 2},
                new HairSubMenu(){ Name = "Others", HairMenuId = 2},

                new HairSubMenu(){ Name = "Cold Perm", HairMenuId = 3},
                new HairSubMenu(){ Name = "Digital Perm", HairMenuId = 3},
                new HairSubMenu(){ Name = "Straight Perm", HairMenuId = 3},
                new HairSubMenu(){ Name = "Partial Perm", HairMenuId = 3},
                new HairSubMenu(){ Name = "Others", HairMenuId = 3}
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
                new HairType(){ Name = "Fleezy" },
                new HairType(){ Name = "High damaged" }
            };
            context.HairTypes.AddRange(hairTypes);
            context.SaveChanges();

            var customers = new[]
            {
                new Customer(){ Name = "Jonh Park", Gender = GenderType.Male, CreatedUserId = 1},
                new Customer(){ Name = "Jenny", Gender = GenderType.Male, CreatedUserId = 1},
                new Customer(){ Name = "Mark Jang", Gender = GenderType.Male, CreatedUserId = 1},
                new Customer(){ Name = "Petric San", Gender = GenderType.Male, CreatedUserId = 1},
                new Customer(){ Name = "Totoro", Gender = GenderType.Male, CreatedUserId = 1}
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
            
            var posts = new[]
            {
                new Post(){ CustomerId = 1, Date = DateTime.Now, Memo = "Test1", SalonId = 1, HairTypeMemo = "too thin", AccessType = AccessType.Public },
                new Post(){ CustomerId = 2, Date = DateTime.Now, Memo = "Test2", SalonId = 2, HairTypeMemo = "Memo 2", AccessType = AccessType.OnlyMe },
                new Post(){ CustomerId = 3, Date = DateTime.Now, Memo = "Test3", SalonId = 1, HairTypeMemo = "Memo 3", AccessType = AccessType.OnlyMe },
                new Post(){ CustomerId = 4, Date = DateTime.Now, Memo = "Test4", SalonId = 2, HairTypeMemo = "Memo 4", AccessType = AccessType.Public },
                new Post(){ CustomerId = 5, Date = DateTime.Now, Memo = "Test4", SalonId = 2, HairTypeMemo = "Memo 5", AccessType = AccessType.Public },
                new Post(){ CustomerId = 1, Date = DateTime.Now, Memo = "Test5", SalonId = 1, HairTypeMemo = "Memo 6", AccessType = AccessType.Public },
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();

            var postComments = new[]
            {
                new PostComment(){ PostId = 1, CreatedUserId = 1, Comment= "Test1" },
                new PostComment(){ PostId = 1, CreatedUserId = 1, Comment= "Test2" },
                new PostComment(){ PostId = 1, CreatedUserId = 1, Comment= "Test3" },
                new PostComment(){ PostId = 2, CreatedUserId = 1, Comment= "Test4" },
                new PostComment(){ PostId = 3, CreatedUserId = 1, Comment= "Test5" },
                new PostComment(){ PostId = 4, CreatedUserId = 1, Comment= "Test6" },
                new PostComment(){ PostId = 5, CreatedUserId = 1, Comment= "Test7" },
            };
            context.PostComments.AddRange(postComments);
            context.SaveChanges();
            
            var postEvaluations = new[]
            {
                new PostEvaluation(){ PostId = 1, CreatedUserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 1, CreatedUserId = 2, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 1, CreatedUserId = 3, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 2, CreatedUserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 3, CreatedUserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 4, CreatedUserId = 1, EvaluationType= EvaluationType.Like },
                new PostEvaluation(){ PostId = 5, CreatedUserId = 1, EvaluationType= EvaluationType.Like },
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

