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
    public partial class Answer
    {
        public int Id { get; set; }
        public Nullable<int> QuestionId { get; set; }
        [Display(Name = "Текст")]
        public string Text { get; set; }
        public bool IsTrue { get; set; }

        public virtual Question Question { get; set; }
    }
}