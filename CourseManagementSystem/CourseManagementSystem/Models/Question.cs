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
    public partial class Question
    {
        public Question()
        {
            this.Answer = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public int LastLectureId { get; set; }
        [Display(Name = "Номер")]
        public int Number { get; set; }
        [Display(Name = "Текст")]
        public string Text { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual Test Test { get; set; }
    }
}