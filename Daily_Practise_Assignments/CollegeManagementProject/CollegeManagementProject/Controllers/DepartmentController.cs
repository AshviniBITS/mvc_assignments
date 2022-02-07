using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeManagementProject.Models;

namespace CollegeManagementProject.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            TeacherDBEntities1 db=new TeacherDBEntities1();
            List<Department> departments = db.Departments.ToList();
            return View(departments);
        }
        public ActionResult create()
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
           

            return View();
        }
        [HttpPost]
        public ActionResult create(Department d,string username)
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
            List<Department> departments = db.Departments.ToList();
            //var userCount = departments.Where(x => x.DeptName.Equals(username)).Select(x => x.DeptId).Count();
            //bool result = userCount > 0 ? false : true;
            //return Json(result, JsonRequestBehavior.AllowGet);

            db.Departments.Add(d);
                db.SaveChanges();
                //return View();
                return RedirectToAction("Index");
        }
       
        public JsonResult delete(int id)
        {
            bool result = false;
            TeacherDBEntities1 db = new TeacherDBEntities1();

            Department dr = db.Departments.Where(temp => temp.DeptId == id).FirstOrDefault();
            db.Departments.Remove(dr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      


    }
}