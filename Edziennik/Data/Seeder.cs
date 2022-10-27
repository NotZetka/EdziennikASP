using Edziennik.Data.Models;
using Edziennik.Utility;
using Microsoft.AspNetCore.Identity;

namespace Edziennik.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public Seeder(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public void seedRoles()
        {
            if (!roleManager.RoleExistsAsync(SD.Role_Admin).Result)
            {
                roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(SD.Role_Teacher).Result)
            {
                roleManager.CreateAsync(new IdentityRole(SD.Role_Teacher)).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(SD.Role_Student).Result)
            {
                roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();
            }
        }
        public void seedClasses()
        {
            if(dbContext.SchoolClasses.ToList().Count() == 0)
            {
                var class1A = new SchoolClass() { Name = "1A" };
                var class2A = new SchoolClass() { Name = "2A" };
                dbContext.SchoolClasses.AddRange(class1A, class2A);
                dbContext.SaveChanges();
            }
        }
        public void seedUsers()
        {
            if (dbContext.Users.ToList().Count != 0)
            {
                userManager.CreateAsync(new Student
                {
                    UserName = "JanKowaslki@Student.pl",
                    Email = "JanKowaslki@Student.pl",
                    FirstName = "Jan",
                    SecondName = "Kowalski",
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Student
                {
                    UserName = "PiotrNowak@Student.pl",
                    Email = "PiotrNowak@Student.pl",
                    FirstName = "Piotr",
                    SecondName = "Nowak",
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Student
                {
                    UserName = "BartoszLewandowski@Student.pl",
                    Email = "BartoszLewandowski@Student.pl",
                    FirstName = "Bartosz",
                    SecondName = "Lewandowski",
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Student
                {
                    UserName = "MichalNowak@Student.pl",
                    Email = "MichalNowak@Student.pl",
                    FirstName = "Michal",
                    SecondName = "Nowak",
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Teacher
                {
                    UserName = "AdamWalczak@Teacher.pl",
                    Email = "AdamWalczak@Teacher.pl",
                    FirstName = "Adam",
                    SecondName = "Walczak"
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Teacher
                {
                    UserName = "GrzegorzKalisz@Teacher.pl",
                    Email = "GrzegorzKalisz@Teacher.pl",
                    FirstName = "Grzegorz",
                    SecondName = "Kalisz"
                }, "Test123.").GetAwaiter().GetResult();
                userManager.CreateAsync(new Teacher
                {
                    UserName = "DominikTuzimek@Teacher.pl",
                    Email = "DominikTuzimek@Teacher.pl",
                    FirstName = "Dominik",
                    SecondName = "Tuzimek"
                }, "Test123.").GetAwaiter().GetResult();
            }
        }
        public void seedStudentsClasses()
        {

            var class1A = dbContext.SchoolClasses.Where(x => x.Name == "1A").FirstOrDefault();
            var class2A = dbContext.SchoolClasses.Where(x => x.Name == "2A").FirstOrDefault();

            if(class1A.Students.Count() == 0)
            {
                var student1 = dbContext.Students.Where(x => x.Email == "JanKowaslki@Student.pl").FirstOrDefault();
                var student2 = dbContext.Students.Where(x => x.Email == "PiotrNowak@Student.pl").FirstOrDefault();
                var student3 = dbContext.Students.Where(x => x.Email == "BartoszLewandowski@Student.pl").FirstOrDefault();
                var student4 = dbContext.Students.Where(x => x.Email == "MichalNowak@Student.pl").FirstOrDefault();

                class1A.Students.Add(student1);
                class1A.Students.Add(student2);
                class2A.Students.Add(student3);
                class2A.Students.Add(student4);
                dbContext.SaveChanges();
            }

        }
        public void seedSchool()
        {
            var student1 = dbContext.Students.Where(x => x.Email == "JanKowaslki@Student.pl").FirstOrDefault();
            userManager.AddToRoleAsync(student1, SD.Role_Student).GetAwaiter().GetResult();

            var student2 = dbContext.Students.Where(x => x.Email == "PiotrNowak@Student.pl").FirstOrDefault();
            userManager.AddToRoleAsync(student2, SD.Role_Student).GetAwaiter().GetResult();

            var student3 = dbContext.Students.Where(x => x.Email == "BartoszLewandowski@Student.pl").FirstOrDefault();
            userManager.AddToRoleAsync(student3, SD.Role_Student).GetAwaiter().GetResult();

            var student4 = dbContext.Students.Where(x => x.Email == "MichalNowak@Student.pl").FirstOrDefault();
            userManager.AddToRoleAsync(student4, SD.Role_Student).GetAwaiter().GetResult();

            var teacher1 = dbContext.Teachers.Where(x => x.Email == "AdamWalczak@Teacher.pl").FirstOrDefault();
            userManager.AddToRoleAsync(teacher1, SD.Role_Teacher).GetAwaiter().GetResult();

            var teacher2 = dbContext.Teachers.Where(x => x.Email == "GrzegorzKalisz@Teacher.pl").FirstOrDefault();
            userManager.AddToRoleAsync(teacher2, SD.Role_Teacher).GetAwaiter().GetResult();

            var teacher3 = dbContext.Teachers.Where(x => x.Email == "DominikTuzimek@Teacher.pl").FirstOrDefault();
            userManager.AddToRoleAsync(teacher3, SD.Role_Teacher).GetAwaiter().GetResult();
            dbContext.SaveChanges();
        }
        public void seedLessons()
        {
            if (dbContext.Lessons.ToList().Count != 0) return;
            var teacher1 = dbContext.Teachers.Where(x => x.Email == "AdamWalczak@Teacher.pl").FirstOrDefault();
            var teacher2 = dbContext.Teachers.Where(x => x.Email == "GrzegorzKalisz@Teacher.pl").FirstOrDefault();
            var teacher3 = dbContext.Teachers.Where(x => x.Email == "DominikTuzimek@Teacher.pl").FirstOrDefault();
            var class1A = dbContext.SchoolClasses.Where(x => x.Name == "1A").FirstOrDefault();
            var class2A = dbContext.SchoolClasses.Where(x => x.Name == "2A").FirstOrDefault();

            var lessons = new List<Lesson>()
            {
                new Lesson(){Number = 1, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subject_Polish},
                new Lesson(){Number = 2, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subject_Polish},
                new Lesson(){Number = 4, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 5, SchoolClass = class1A, Teacher = teacher3, Subject = SD.Subjest_PE},
                new Lesson(){Number = 2, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 3, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 4, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subjest_CS},
                new Lesson(){Number = 11, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subjest_Psyhics},
                new Lesson(){Number = 12, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subjest_PE},
                new Lesson(){Number = 13, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 11, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 12, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 14, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subjest_CS},
                new Lesson(){Number = 15, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subjest_CS},
                new Lesson(){Number = 17, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subjest_Psyhics},
                new Lesson(){Number = 18, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subjest_PE},
                new Lesson(){Number = 17, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subjest_PE},
                new Lesson(){Number = 18, SchoolClass = class2A, Teacher = teacher1, Subject = SD.Subject_Maths},
                new Lesson(){Number = 19, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subjest_Psyhics},
                new Lesson(){Number = 20, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subjest_Psyhics},
                new Lesson(){Number = 21, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subjest_CS},
                new Lesson(){Number = 22, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subjest_CS},
                new Lesson(){Number = 26, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 27, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 28, SchoolClass = class1A, Teacher = teacher1, Subject = SD.Subjest_PE},
                new Lesson(){Number = 29, SchoolClass = class1A, Teacher = teacher3, Subject = SD.Subject_Polish},
                new Lesson(){Number = 33, SchoolClass = class1A, Teacher = teacher3, Subject = SD.Subject_Polish},
                new Lesson(){Number = 33, SchoolClass = class2A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 34, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subject_Maths},
                new Lesson(){Number = 34, SchoolClass = class2A, Teacher = teacher3, Subject = SD.Subject_Polish},
                new Lesson(){Number = 35, SchoolClass = class1A, Teacher = teacher3, Subject = SD.Subjest_PE},
                new Lesson(){Number = 35, SchoolClass = class2A, Teacher = teacher1, Subject = SD.Subjest_Psyhics},
                new Lesson(){Number = 36, SchoolClass = class1A, Teacher = teacher2, Subject = SD.Subjest_CS},
                new Lesson(){Number = 36, SchoolClass = class2A, Teacher = teacher1, Subject = SD.Subjest_Psyhics},
            };
        dbContext.Lessons.AddRange(lessons);
        dbContext.SaveChanges();
        }
    }
}
