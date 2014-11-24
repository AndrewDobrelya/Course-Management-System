using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public class CourseMark
    {
        [Key]
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public Course course { get; set; }
        public int mark { get; set; }
    }
}