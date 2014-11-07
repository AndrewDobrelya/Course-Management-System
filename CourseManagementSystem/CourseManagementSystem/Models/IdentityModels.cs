using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CourseManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MailNotExists]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Answer> Answer { get; set; }

        public DbSet<Lecture> Lecture { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<Subscription> Subscription { get; set; }

        public DbSet<Test> Test { get; set; }

    }

    public class MailNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var user = db.Users.FirstOrDefaultAsync(u => u.Email == (string)value);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Электронная почта используется другим пользователем");
        }
    }
}