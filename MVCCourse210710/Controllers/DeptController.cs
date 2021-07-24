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
using Omu.ValueInjecter;
using MVCCourse210710.ActionFilterAttributes;

namespace MVCCourse210710.Controllers
{
    public class DeptController : BaseController
    {
        DepartmentRepository DeptRepo = RepositoryHelper.GetDepartmentRepository();
        PersonRepository PersonRepo = RepositoryHelper.GetPersonRepository();
        CourseRepository CourseRepo;
        // GET: Dept
        public DeptController()
        {
            DeptRepo.UnitOfWork.Context.Database.Log = (msg) => Debug.WriteLine(msg);        //在偵錯時將EF做了甚麼操作列在輸出視窗
            CourseRepo = RepositoryHelper.GetCourseRepository(DeptRepo.UnitOfWork);     //用同一個連線
        }
        public ActionResult Index()
        {
            return View(DeptRepo.All());
        }

        [PersonSelectListForViewByViewBag]
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(PersonRepo.GetPersonSelect(), "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PersonSelectListForViewByViewBag]
        [HandleError(ExceptionType = typeof(DbEntityValidationException),View = "DbEntityValidationException")]
        public ActionResult Create(DepartmentCreate departmentCreate)
        {
                if (ModelState.IsValid)
            {
                Department department = new Department();
                department.InjectFrom(departmentCreate);
                DeptRepo.Add(department);
                DeptRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(departmentCreate);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptRepo.All().FirstOrDefault(d => d.DepartmentID == id); 
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        public ActionResult Detail_Courses(int? DepartmentID)
        {
            if (DepartmentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(CourseRepo.Where(c => c.DepartmentID == DepartmentID));
        }
        // GET: Departments/Edit/5
        [PersonSelectListForViewByViewBag]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptRepo.All().FirstOrDefault(d => d.DepartmentID == id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        // POST: Departments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PersonSelectListForViewByViewBag]
        public ActionResult Edit(int? id, DepartmentEdit departmentEdit)
        {
            if (ModelState.IsValid)
            {
                Department department = DeptRepo.All().FirstOrDefault(d => d.DepartmentID == id);
                department.InjectFrom(departmentEdit);
                try
                {
                    DeptRepo.UnitOfWork.Commit();
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

            return View(departmentEdit);
        }

        public ActionResult BatchEdit()
        {
            return View(db.Department.Include(d=>d.Manager));
        }

        [HttpPost]
        public ActionResult BatchEdit(BatchEditViewModel[] data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var findOne = DeptRepo.FindOne(item.DepartmentID);
                    findOne.InjectFrom(item);
                }
                try
                {
                    DeptRepo.UnitOfWork.Commit();
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

            return View(db.Department.Include(d => d.Manager));
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = DeptRepo.All().FirstOrDefault(d => d.DepartmentID == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, DepartmentDelete departmentDelete)
        {
            Department department = DeptRepo.All().FirstOrDefault(d => d.DepartmentID == id);
            DeptRepo.Delete(department);
            DeptRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}