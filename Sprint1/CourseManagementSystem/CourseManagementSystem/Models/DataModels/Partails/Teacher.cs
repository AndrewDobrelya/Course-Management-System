namespace CourseManagementSystem.Models.DataModels
{
    public partial class Teacher
    {
        public static explicit operator UserModel(Teacher teacher)
        {
            if (teacher == null)
                return null;
            return new UserModel()
            {
                Id = teacher.TeacherId,
                Login = teacher.Login,
                Name = teacher.Name,
                Password = teacher.Password,
                UserType = UserType.Teacher,
                LastName = teacher.LastName,
                Email = teacher.Email,
            };
        }
    }
}