//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseManagementSystem.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
            this.TeacherComments = new HashSet<TeacherComment>();
        }
    
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public System.DateTime RegDate { get; set; }
        public int Activation { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<TeacherComment> TeacherComments { get; set; }
    }
}
