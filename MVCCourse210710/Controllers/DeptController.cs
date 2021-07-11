using MVCCourse210710.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MVCCourse210710.ViewModels;
using System.Net;
using System.Data.Entity.Validation;

namespace MVCCourse210710.Controllers
{
    public class DeptController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();
        // GET: Dept
        public DeptController()
        {
            db.Database.Log = (msg) => Debug.WriteLine(msg);        //在偵錯時將EF做了甚麼操作列在輸出視窗
        }
        public ActionResult Index()
        {
            return View(db.Department.Include(d => d.Manager));
        }

        public ActionResult Create()
        {
            var personDDLList = db.Person.Select(p => new
            {
                p.ID,
                Name = p.FirstName + " " + p.LastName
            });
            ViewBag.InstructorID = new SelectList(personDDLList, "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentCreate departmentCreate)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.Name = departmentCreate.Name;
                department.Budget = departmentCreate.Budget;
                department.InstructorID = departmentCreate.InstructorID;
                department.StartDate = DateTime.Now;

                db.Department.Add(department);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach(var eves in ex.EntityValidationErrors)
                    {
                        foreach (var ves in eves.ValidationErrors)
                        {
                            throw new Exception(ves.PropertyName + " : " + ves.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            var personDDLList = db.Person.Select(p => new
            {
                p.ID,
                Name = p.FirstName + " " + p.LastName
            });
            ViewBag.InstructorID = new SelectList(personDDLList, "ID", "Name");

            return View(departmentCreate);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            DepartmentEdit departmentEdit = new DepartmentEdit();
            departmentEdit.DepartmentID = department.DepartmentID;
            departmentEdit.Name = department.Name;
            departmentEdit.Budget = department.Budget;
            departmentEdit.InstructorID = department.InstructorID;

            var personDDLList = db.Person.Select(p => new
            {
                p.ID,
                Name = p.FirstName + " " + p.LastName
            });
            ViewBag.InstructorID = new SelectList(personDDLList, "ID", "Name");

            return View(departmentEdit);
        }

        // POST: Departments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, DepartmentEdit departmentEdit)
        {
            Department department = new Department();
            if (ModelState.IsValid)
            {
                department = db.Department.Find(id);
                department.DepartmentID = departmentEdit.DepartmentID;
                department.Name = departmentEdit.Name;
                department.Budget = departmentEdit.Budget;
                department.InstructorID = departmentEdit.InstructorID;

                db.Department.Add(department);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eves in ex.EntityValidationErrors)
                    {
                        foreach (var ves in eves.ValidationErrors)
                        {
                            throw new Exception(ves.PropertyName + " : " + ves.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            var personDDLList = db.Person.Select(p => new
            {
                p.ID,
                Name = p.FirstName + " " + p.LastName
            });
            ViewBag.InstructorID = new SelectList(personDDLList, "ID", "Name");

            return View(departmentEdit);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentDelete departmentDelete = new DepartmentDelete();
            departmentDelete.Name = department.Name;
            return View(departmentDelete);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, DepartmentDelete departmentDelete)
        {
            Department department = db.Department.Find(id);
            departmentDelete.Name = department.Name;

            db.Department.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}