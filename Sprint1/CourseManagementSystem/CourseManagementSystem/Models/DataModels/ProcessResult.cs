using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models.DataModels
{
    public class ProcessResult
    {
        public int Id { get; private set; }

        public bool Succeeded { get; private set; }

        public string Message { get; set; }

        public bool IsEmpty
        {
            get { return Succeeded == false && Message == null; }
        }

        public ProcessResult(int id, bool succeeded, string message)
        {
            Id = id;
            Succeeded = succeeded;
            Message = message;
        }

    }

    public class ProcessResults
    {
        static readonly ProcessResult[] Results =
        {
             new ProcessResult(0, false, "Неверный email или пароль!"), 
            new ProcessResult(1, false, "Пользователь с такими данными уже существует!"),
            new ProcessResult(2, true, "Вы успешно прошли регестрацию. На Ваш почтовый ящик выслано письмо с подтверждением регистрации!"),
            new ProcessResult(3, true, "Регистраци подтверждена! Теперь Вы можете пользоваться своим личным кабинетом!"),
            new ProcessResult(4, true, "Вы вошли в личный кабинет!"),
            new ProcessResult(5, false, "Произошла ошибка!"),
            new ProcessResult(6, true, "Профиль успешно отредактирован! изменения вступили в силу!"),
        };

        public static ProcessResult InvalidEmailOrPassword
        {
            get { return Results[0]; }
        }

        public static ProcessResult UserAlreadyExists
        {
            get { return Results[1]; }
        }

        public static ProcessResult RegistrationCompleted
        {
            get { return Results[2]; }
        }

        public static ProcessResult RegistrationConfirmed
        {
            get { return Results[3]; }
        }

        public static ProcessResult LoggedInSuccessfull
        {
            get { return Results[4]; }
        }

        public static ProcessResult ErrorOccured
        {
            get { return Results[5]; }
        }

        public static ProcessResult ProfileEditedSuccessfully
        {
            get { return Results[6]; }
        }
    }
}