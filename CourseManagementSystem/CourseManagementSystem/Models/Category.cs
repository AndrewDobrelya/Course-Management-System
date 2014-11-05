using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CourseManagementSystem.Models
{
    public partial class Category
    {
        public int id { get; set; }

        public Category()
        {
            this.Course = new HashSet<Course>();
        }

        [Display(Name = "Категория")]
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
       
}