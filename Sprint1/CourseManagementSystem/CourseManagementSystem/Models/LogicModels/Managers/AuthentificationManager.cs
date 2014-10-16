using CourseManagementSystem.Models.DataModels;
using CourseManagementSystem.Models.LogicModels.Services;
using CourseManagementSystem.Models.LogicModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models.LogicModels.Managers
{
    public class AuthentificationManager : Manager
    {
        public ProcessResult LogInUser(LoginModel model, out UserModel userModel)
        {
            if (model.UserType == UserType.Teacher)
                userModel = (UserModel)DataManager.Teacher.LogInTeacher(model);
            else
                userModel = (UserModel)DataManager.Student.LogInStudent(model);

            if (userModel == null)
                return ProcessResults.InvalidEmailOrPassword;

            return ProcessResults.LoggedInSuccessfull;
        }

        public ProcessResult ConfirmRegistration(string hash)
        {
            var students = entities.Students.ToList();
            var teachers = entities.Teachers.ToList();

            foreach (var teacher in teachers)
            {
                string curHash = Security.GetHashString(teacher.Email + teacher.Password + UserType.Teacher.ToString());
                if (curHash == hash)
                {
                    teacher.Activation = (int)UserStatus.Confirmed;
                    SaveChanges();
                    return ProcessResults.RegistrationConfirmed;
                }
            }

            foreach (var student in students)
            {
                string curHash = Security.GetHashString(student.Email + student.Password + UserType.Student.ToString());
                if (curHash == hash)
                {
                    student.Activation = (int)UserStatus.Confirmed;
                    SaveChanges();
                    return ProcessResults.RegistrationConfirmed;
                }
            }

            return ProcessResults.ErrorOccured;
        }
    }
}