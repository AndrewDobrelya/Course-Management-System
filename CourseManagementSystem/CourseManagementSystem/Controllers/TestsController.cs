using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManagementSystem.Models;

namespace CourseManagementSystem.Controllers
{
    public class TestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tests
        public ActionResult Index()
        {
            return View(db.Test.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/CreateTest
        public ActionResult CreateTest()
        {
            List<Lecture> q = db.Lecture.ToList();
            List<SelectListItem> lects = new List<SelectListItem>();

            foreach (var i in q)
            {
                lects.Add(new SelectListItem { Text = i.Name + " (id = " + i.Id + ")" });
            }

            ViewBag.Lectures = lects;
            return View();
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTest([Bind(Include = "Id,Number")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }


        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastLectureId,Number")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastLectureId,Number")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Test.Find(id);
            Question[] q = db.Question.ToArray<Question>();
            for (int i = 0; i < q.Count(); i++)
            {
                if (q[i].Test.Id == id)
                {
                    deleteAnswers(q[i].QuestionId, q[i]);
                }
            }
            db.SaveChanges();
            db.Test.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void deleteAnswers(int id, Question question)
        {
            Answer[] a = db.Answer.ToArray<Answer>();
            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i].QuestionId == id)
                {
                    db.Answer.Remove(a[i]);
                }
            }
            db.SaveChanges();
            db.Question.Remove(question);
            db.SaveChanges();
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
