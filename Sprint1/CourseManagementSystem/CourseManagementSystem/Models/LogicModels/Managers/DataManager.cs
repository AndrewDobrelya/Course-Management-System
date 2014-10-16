using CourseManagementSystem.Models.LogicModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models.LogicModels.Managers
{
    public class DataManager
    {
        public static TeacherManager Teacher { get; private set; }
        public static StudentManager Student { get; private set; }

        static DataManager()
        {
            Teacher = new TeacherManager();
            Student = new StudentManager();
        }
        public static UserModel DefineUser(HttpContextBase context)
        {
            var cookieUser = context.Request.Cookies["UserId"];
            var cookieKey = context.Request.Cookies["Key"];
            var cookieUserType = context.Request.Cookies["UserType"];
            UserModel user = null;
            if (cookieUser != null && cookieKey != null && cookieUserType != null)
            {
                UserType userType = (UserType)Convert.ToInt32(cookieUserType.Value);
                int id = Convert.ToInt32(cookieUser.Value);

                if (userType == UserType.Teacher)
                    user = (UserModel)DataManager.Teacher.GetTeacher(x => x.TeacherId == id);
                else if (userType == UserType.Student)
                    user = (UserModel)DataManager.Student.GetStudent(x => x.StudentId == id);
            }

            if (user != null && !KeyMatch(user, cookieKey.Value))
                user = null;

            return user;
        }

        private static bool KeyMatch(UserModel user, string key)
        {
            if (user == null)
                return false;
            return user.Password == key;
        }
    }
}