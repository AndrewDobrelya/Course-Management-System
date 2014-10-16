namespace CourseManagementSystem.Models.DataModels
{
    public partial class Student
    {
        public static explicit operator UserModel(Student student)
        {
            if (student == null)
                return null;
            return new UserModel()
            {
                Id = student.StudentId,
                Login = student.Login,
                Name = student.Name,
                Password = student.Password,
                UserType = UserType.Student,
                LastName = student.LastName,
                Email = student.Email,

            };
        }
    }
}