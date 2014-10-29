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
        public Category()
        {
            this.Course = new HashSet<Course>();
        }

        public int id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
       
}