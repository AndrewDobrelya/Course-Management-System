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
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        [Display(Name = "Подписчик")]
        public ApplicationUser Subscriber { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }        
    }
}