using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManagementSystem.Models;
using CourseManagementSystem.Models.DataModels;
using CourseManagementSystem.Models.LogicModels.Managers;
using CourseManagementSystem.Models.LogicModels.Services;
using CourseManagementSystem.Models.LogicModels.ViewModels;


namespace CourseManagementSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

    }
}
