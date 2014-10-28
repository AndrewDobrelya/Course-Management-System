using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public class Course
    {
        
        public int id { get; set; }

        [Display(Name = "Название")]
        public string name { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Категория")]
        public Category Category { get; set; }

        [Display(Name = "Автор")]
        public ApplicationUser Author { get; set; }

        [Display(Name = "Статус")]
        public bool activated { get; set; }


    }

}