using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public partial class Lecture
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }

        public virtual Course Course { get; set; }
    }
}