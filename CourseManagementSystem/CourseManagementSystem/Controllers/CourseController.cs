using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Controllers
{
    public class CourseController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: /Course/

        [Authorize(Roles = "teacher")]
        public ActionResult Teacher()
        {
            
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            List<Course> FullList = db.Courses.ToList();
            List<Course> AuthorList = new List<Course>();
            foreach(Course course in FullList)
            {
                if(course.Author == userManager.FindById(User.Identity.GetUserId()))
                {
                    AuthorList.Add(course);
                }
            }
            return View(AuthorList);
        }



        // GET: /Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Course/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCourseModel courseview)
        {

            if (ModelState.IsValid)
            {

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var course = new Course() { name = courseview.name, description = courseview.description, Category = db.Categories.Find(courseview.category_id) };
                course.PublishDate = DateTime.Now;
                course.activated = false;
                course.Author = userManager.FindById(User.Identity.GetUserId());
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseview);
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(new AddCourseModel(course));
        }

        // POST: /Course/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddCourseModel courseview)
        {
            if (ModelState.IsValid)
            {
                var course = db.Courses.Find(courseview.id);
                course.name = courseview.name;
                course.description = courseview.description;
                course.Category = db.Categories.Find(courseview.category_id);

                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseview);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
