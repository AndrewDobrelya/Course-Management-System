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
    
    public partial class StudentComment
    {
        public StudentComment()
        {
            this.TeacherComments = new HashSet<TeacherComment>();
        }
    
        public int StudentCommentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public System.DateTime CommentDate { get; set; }
        public string Text { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<TeacherComment> TeacherComments { get; set; }
    }
}