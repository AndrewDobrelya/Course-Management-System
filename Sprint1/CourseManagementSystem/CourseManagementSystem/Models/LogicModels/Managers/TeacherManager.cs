using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseManagementSystem.Models.DataModels;
using CourseManagementSystem.Models.LogicModels.ViewModels;
using CourseManagementSystem.Models.LogicModels.Services;

namespace CourseManagementSystem.Models.LogicModels.Managers
{
    public class TeacherManager : Manager
    {
        public ProcessResult RegistrateTeacher(
            HttpContextBase context,
            Teacher teacher,
            HttpServerUtilityBase server,
            HttpPostedFileBase imageUpload)
        {
            Func<Teacher, bool> func = x => x.Email == teacher.Email;
            var exists = GetTeacher(func);
            teacher.Password = Security.GetHashString(teacher.Password);
            teacher.Activation = (int)UserStatus.Unconfirmed;
            if (exists != null)
                return ProcessResults.UserAlreadyExists;



            if (!SendConfirmationMail(context,
                teacher.Email,
                teacher.Password,
                UserType.Teacher.ToString()) ||
                !SendLecturerConfirmationMail(teacher.Name + " " + teacher.LastName, teacher.Email))
                return ProcessResults.ErrorOccured;



            var st = entities.Teachers.Add(teacher);
            SaveChanges();
            return ProcessResults.RegistrationCompleted;
        }

        public Teacher LogInTeacher(LoginModel model)
        {
            var find = entities.Teachers.ToList().FirstOrDefault(x =>
                (x.Login == model.LoginOrEmail ||
                x.Email == model.LoginOrEmail) &&
                model.Password == x.Password);

            if (find == null)
                return null;

           
            SaveChanges();
            return find;
        }

        public Teacher GetTeacher(int id)
        {
            return entities.Teachers.FirstOrDefault(x => x.TeacherId == id);
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return entities.Teachers;
        }

        public bool RemoveTeacher(int teacherId)
        {
            var teacherToRemove = entities.Teachers.FirstOrDefault(x => x.TeacherId == teacherId);
            if (teacherToRemove == null)
                return false;

            entities.Teachers.Remove(teacherToRemove);
            SaveChanges();
            return true;
        }

        public Teacher GetTeacher(Func<Teacher, bool> predicate, bool confirmedOnly = true)
        {
            foreach (var teacher in entities.Teachers.ToList())
            {
                if (confirmedOnly)
                {
                    if (predicate(teacher) && (UserStatus)teacher.Activation == UserStatus.Confirmed)
                        return teacher;
                }
                else
                {
                    if (predicate(teacher))
                        return teacher;
                }
            }

            return null;

        }

        public ProcessResult EditTeacher(Teacher newTeacher,
            HttpServerUtilityBase server)
        {
            var teacherToEdit = entities.Teachers.FirstOrDefault(x => x.TeacherId == newTeacher.TeacherId);
            if (teacherToEdit == null)
                return ProcessResults.ErrorOccured;

            teacherToEdit.Login = newTeacher.Login;
            teacherToEdit.Name = newTeacher.Name;
            if (!String.IsNullOrEmpty(newTeacher.Password))
                teacherToEdit.Password = Security.GetHashString(newTeacher.Password);
            teacherToEdit.Email = newTeacher.Email;
            teacherToEdit.LastName = newTeacher.LastName;
            SaveChanges();
            return ProcessResults.ProfileEditedSuccessfully;
        }

    }
}