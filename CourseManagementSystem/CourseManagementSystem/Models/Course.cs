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
    public partial class Course
    {
        
        public int id { get; set; }

        [Display(Name = "Название")]
        public string name { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        [Display(Name = "Дата публикации")]
        public System.DateTime PublishDate { get; set; }

        [Display(Name = "Оценка")]
        public Nullable<double> Estimation { get; set; }

        [Display(Name = "Количество оценок")]
        public Nullable<int> EstimationCount { get; set; }

        [Display(Name = "Категория")]
        public virtual Category Category { get; set; }

        [Display(Name = "Автор")]
        public virtual ApplicationUser Author { get; set; }

        [Display(Name = "Статус")]
        public bool activated { get; set; }
 


    }
    public partial class AddCourseModel
    {
        public AddCourseModel(Course course) 
        {
            id = course.id;
            name = course.name;
            description = course.description;
            category_id = course.Category.id;
        
        }

        public AddCourseModel()
        {

        }


        public int id { get; set; }

        [Display(Name = "Название")]
        public string name { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        [Display(Name = "Категория")]
        public int category_id { get; set; }





    }


}