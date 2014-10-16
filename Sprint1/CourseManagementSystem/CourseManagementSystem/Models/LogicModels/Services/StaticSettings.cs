namespace CourseManagementSystem.Models.LogicModels.Services
{
    using System;

    public class StaticSettings
    {
        public static int MinUserExperince
        {
            get { return 10; }
        }

        public static string ConfirmationMessage
        {
            get
            {
                return "Для подтверждения регистрации перейдите по ссылке : ";
            }
        }

        public static String TeacherRegistration
        {
            get
            {
                return "Регистрация преподавателя";
            }
        }

        public static string ConfirmationTitle
        {
            get { return "Подтверждение регистрации"; }
        }
    }
}