using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseManagementSystem.Models.LogicModels.Services;
using CourseManagementSystem.Models.DataModels;

namespace CourseManagementSystem.Models.LogicModels.Managers
{
    using System.Configuration;

    public abstract class Manager
    {
        protected CourseDataBaseEntities entities;

        public Manager()
        {
            entities = new CourseDataBaseEntities();
        }

        protected bool SendLecturerConfirmationMail(string fio, string email)
        {
            var confirmationMailSender = new ConfirmationMailSender();
            var info = String.Format(ConfigurationManager.AppSettings["TeacherRegistrationMessage"], fio, email);
            return confirmationMailSender.Send(
                StaticSettings.TeacherRegistration,
                info,
                ConfigurationManager.AppSettings["RegitrateLecturer"]);
        }
        protected bool SendConfirmationMail(HttpContextBase context, string email, string password, string type)
        {
            var confirmationMessageSender = new ConfirmationMailSender();
            string token = Security.GetHashString(email + password + type);

            if (context.Request.Url != null)
            {
                string path = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/User/Confirm?hash=" + token;
                string message = String.Format(StaticSettings.ConfirmationMessage + "{0}", path);
                return confirmationMessageSender.Send(StaticSettings.ConfirmationTitle, message, email);
            }

            return false;
        }
        protected void SaveChanges()
        {
            entities.SaveChanges();
        }

    }
}