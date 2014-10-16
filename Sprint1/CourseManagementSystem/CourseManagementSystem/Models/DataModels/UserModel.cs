namespace CourseManagementSystem.Models
{
    public enum UserType
    {
        Student,
        Teacher,
        Moderator
    };

    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public bool HasModeratorAccess()
        {
            return UserType == Models.UserType.Teacher || UserType == Models.UserType.Moderator;
        }
    }
}