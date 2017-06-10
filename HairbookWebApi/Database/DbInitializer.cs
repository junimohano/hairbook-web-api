using HairbookWebApi.Models;
using System;
using System.Linq;

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

            var users = new User[]
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

            var hairMenus = new HairMenu[]
            {
                new HairMenu(){ Name = "Cut" },
                new HairMenu(){ Name = "Color" },
                new HairMenu(){ Name = "Parm" },
                new HairMenu(){ Name = "Wb" },
                new HairMenu(){ Name = "Updo" }
            };

            context.HairMenus.AddRange(hairMenus);
            context.SaveChanges();

            var hairTypes = new HairType[]
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
          
        }
    }
}

