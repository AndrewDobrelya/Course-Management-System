using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public partial class Lecture
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Содержание")]
        public string Text { get; set; }
        public int Number { get; set; }

        public virtual Course Course { get; set; }
    }
}