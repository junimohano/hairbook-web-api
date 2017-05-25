using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Db
{
    public class DbInitializer
    {
        public static void Initialize(HairbookContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Boards.Any())
            {
                return;   // DB has been seeded
            }

            var boards = new User[]
            {
                new User{FirstName= "11111111",LastName= "test1",CreatedDate= DateTime.Now},
                new User{FirstName= "222222222",LastName= "test2",CreatedDate= DateTime.Now},
            };
            foreach (User b in boards)
            {
                context.Boards.Add(b);
            }
            context.SaveChanges();

            //var courses = new Course[]
            //{
            //new Course{CourseId=1050,Title="Chemistry",Credits=3,},
            //new Course{CourseId=4022,Title="Microeconomics",Credits=3,},
            //new Course{CourseId=4041,Title="Macroeconomics",Credits=3,},
            //new Course{CourseId=1045,Title="Calculus",Credits=4,},
            //new Course{CourseId=3141,Title="Trigonometry",Credits=4,},
            //new Course{CourseId=2021,Title="Composition",Credits=3,},
            //new Course{CourseId=2042,Title="Literature",Credits=4,}
            //};
            //foreach (Course c in courses)
            //{
            //    context.Courses.Add(c);
            //}
            //context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //new Enrollment{StudentId=1,CourseId=1050,Grade=Grade.A},
            //new Enrollment{StudentId=1,CourseId=4022,Grade=Grade.C},
            //new Enrollment{StudentId=1,CourseId=4041,Grade=Grade.B},
            //new Enrollment{StudentId=2,CourseId=1045,Grade=Grade.B},
            //new Enrollment{StudentId=2,CourseId=3141,Grade=Grade.F},
            //new Enrollment{StudentId=2,CourseId=2021,Grade=Grade.F},
            //new Enrollment{StudentId=3,CourseId=1050},
            //new Enrollment{StudentId=4,CourseId=1050,},
            //new Enrollment{StudentId=4,CourseId=4022,Grade=Grade.F},
            //new Enrollment{StudentId=5,CourseId=4041,Grade=Grade.C},
            //new Enrollment{StudentId=6,CourseId=1045},
            //new Enrollment{StudentId=7,CourseId=3141,Grade=Grade.A},
            //};
            //foreach (Enrollment e in enrollments)
            //{
            //    context.Enrollments.Add(e);
            //}
            //context.SaveChanges();
        }
    }
}

