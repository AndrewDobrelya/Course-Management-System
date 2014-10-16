using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseManagementSystem.Models.DataModels;
using CourseManagementSystem.Models.LogicModels.ViewModels;
using CourseManagementSystem.Models.LogicModels.Services;

namespace CourseManagementSystem.Models.LogicModels.Managers
{
    public class StudentManager : Manager
    {
        public ProcessResult RegistrateStudent(
            HttpContextBase context,
            Student student,
            HttpServerUtilityBase server)
        {
            Func<Student, bool> func = x => x.Email == student.Email && x.Login == student.Login;
            var exists = GetStudent(func);
            student.Password = Security.GetHashString(student.Password);
            student.Activation = (int)UserStatus.Unconfirmed;
            if (exists != null)
                return ProcessResults.UserAlreadyExists;


            if (!SendConfirmationMail(context, student.Email, student.Password, UserType.Student.ToString()))
                return ProcessResults.ErrorOccured;
            student.RegDate = DateTime.Now;
            var st = entities.Students.Add(student);
            SaveChanges();
            return ProcessResults.RegistrationCompleted;
                
        }

        public Student LogInStudent(LoginModel model)
        {
            var find = entities.Students.ToList().FirstOrDefault(x =>
                (x.Login == model.LoginOrEmail ||
                x.Email == model.LoginOrEmail) &&
                model.Password == x.Password);

            if (find == null)
                return null;

            SaveChanges();
            return find;
        }

        public Student GetStudent(int studentId)
        {
            return entities.Students.FirstOrDefault(x => x.StudentId == studentId);
        }

        public Student GetStudent(Func<Student, bool> predicate, bool confirmedOnly = false)
        {
            foreach (var student in entities.Students.ToList())
            {
                if (confirmedOnly)
                {
                    if (predicate(student) && (UserStatus)student.Activation == UserStatus.Confirmed)
                        return student;
                }
                else
                {
                    if (predicate(student))
                        return student;
                }
            }

            return null;
        }

        public bool RemoveStudent(int studentId)
        {
            var studentToRemove = entities.Students.FirstOrDefault(x => x.StudentId == studentId);
            if (studentToRemove == null)
                return false;

            entities.Students.Remove(studentToRemove);
            SaveChanges();
            return true;
        }

        public IEnumerable<Student> GetStudents()
        {
            return entities.Students.ToList();
        }

        public ProcessResult EditStudent(Student newStudent,
            HttpServerUtilityBase server,
            HttpPostedFileBase imageUpload)
        {
            var studentToEdit = entities.Students.FirstOrDefault(x => x.StudentId == newStudent.StudentId);
            if (studentToEdit == null)
                return ProcessResults.ErrorOccured;

            studentToEdit.Login = newStudent.Login;
            studentToEdit.Name = newStudent.Name;
            if (!String.IsNullOrEmpty(newStudent.Password))
                studentToEdit.Password = Security.GetHashString(newStudent.Password);
            studentToEdit.Email = newStudent.Email;
            studentToEdit.LastName = newStudent.LastName;
            SaveChanges();
            return ProcessResults.ProfileEditedSuccessfully;
        }
        public StudentConnection AddStudentConnection(int studentId, int connectionId)
        {
            var studConnection = entities.StudentConnections.Add(new StudentConnection()
            {
               StudentId = studentId
            });

            SaveChanges();
            return studConnection;
        }

        public bool RemoveStudentConnection(int studentConnectionId)
        {
            var connectionToRemove = entities.StudentConnections.FirstOrDefault(x => x.StudentConnectionId == studentConnectionId);
            if (connectionToRemove == null)
                return false;

            entities.StudentConnections.Remove(connectionToRemove);
            SaveChanges();
            return true;
        }
    }
}