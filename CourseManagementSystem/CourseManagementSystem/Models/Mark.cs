using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public class Mark
    {
        public int id { get; set; }

        public virtual Subscription Subscription { get; set; }

        public int Value { get; set; }
    }
}