using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public class Mark
    {
        public int id { get; set; }

        public ApplicationUser Student { get; set; }

        public Test Test { get; set; }

        public int Value { get; set; }
    }
}