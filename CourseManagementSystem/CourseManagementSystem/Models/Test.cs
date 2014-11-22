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
    public partial class Test
    {

        public int Id { get; set; }
        public Test()
        {
            this.Question = new HashSet<Question>();
        }

        [Display(Name = "Имя лекции")]
        public int LastLectureId { get; set; }
        [Display(Name = "Номер")]
        public int Number { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}