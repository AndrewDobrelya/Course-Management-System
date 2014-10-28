using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.DAL 
{
    public class CoursesInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var categories = new List<Category> 
            { 
                new Category { Name = "Chemistry", }, 
                new Category { Name = "Microeconomics",}, 
                new Category { Name = "Macroeconomics",}, 
                new Category { Name = "Calculus", }, 
                new Category { Name = "Trigonometry", }, 
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges(); 
        }
    }
}