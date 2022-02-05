using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeManagementProject.Models;


namespace CollegeManagementProject.Controllers
{
    public class TeacherController : Controller
    {
        public HttpFileCollectionBase HttpFileCollectionBase { get; private set; }

        // GET: Teacher
        public ActionResult Index(string teacherName="", string email="",string DeptName="",string SortColumn = "ProductName", string IconClass = "fa-sort-asc" ,int PageNo = 1)
        {
           
            TeacherDBEntities1 db = new TeacherDBEntities1();
            //List<Teacher> teachers = db.Teachers.Where(temp => temp.teacherName.Contains(search)).ToList();
            List<Teacher> teachers = db.Teachers.ToList();
            //ViewBag.search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            //Sorting
            if (ViewBag.SortColumn == "ProductId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.teacherId).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.teacherId).ToList();
            }
            if (ViewBag.SortColumn == "teacherName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.teacherName).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.teacherName).ToList();
            }
            if (ViewBag.SortColumn == "Email")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.Email).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.Email).ToList();
            }
            if (ViewBag.SortColumn == "PhoneNo")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.PhoneNo).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.PhoneNo).ToList();
            }
            if (ViewBag.SortColumn == "DateOfJoining")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.DateOfJoining).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.DateOfJoining).ToList();
            }
            if (ViewBag.SortColumn == "Address")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers = teachers.OrderBy(temp => temp.Address).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.Address).ToList();
            }
            if (ViewBag.SortColumn == "DeptId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    teachers =teachers.OrderBy(temp => temp.DeptId).ToList();
                else
                    teachers = teachers.OrderByDescending(temp => temp.DeptId).ToList();
            }
            

            /*Pging*/
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(teachers.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            teachers = teachers.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            if (teacherName != "" && email != "" && DeptName != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.teacherName.Contains(teacherName) && temp.Email.Contains(email) && temp.Department.DeptName.Contains(DeptName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.teacherName = teacherName;
                ViewBag.email = email;
                ViewBag.DeptName = DeptName;
                return View(tlist);
            }
            else if (teacherName != "" && email != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.teacherName.Contains(teacherName) && temp.Email.Contains(email)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.teacherName = teacherName;
                ViewBag.email = email;
                return View(tlist);
            }
            else if (teacherName != "" && DeptName != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.teacherName.Contains(teacherName) && temp.Department.DeptName.Contains(DeptName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.teacherName = teacherName;
                ViewBag.email = DeptName;
                return View(tlist);
            }
            else if (email!= "" && DeptName != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.Email.Contains(email) && temp.Department.DeptName.Contains(DeptName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.email = email;
                ViewBag.DeptName = DeptName;
                return View(tlist);
            }
            else if (email != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.Email.Contains(email) ).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.email = email;
               
                return View(tlist);
            }
            else if (DeptName != "")
            {
                List<Teacher> tlist = db.Teachers.Where(temp=>temp.Department.DeptName.Contains(DeptName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
               
                ViewBag.DeptName = DeptName;
                return View(tlist);
            }
            else if (teacherName!="")
            {
                List<Teacher> tlist = db.Teachers.Where(temp => temp.teacherName.Contains(teacherName) ).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tlist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.teacherName = teacherName;
                
                return View(tlist);
            }



            return View(teachers);

            
        }
        public ActionResult Details(int  id)
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
            Teacher t = db.Teachers.Where(temp => temp.teacherId == id).FirstOrDefault();
            return View(t);
        }
        public ActionResult create()
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
            ViewBag.Departments = db.Departments.ToList();
            

            return View();
        }
        [HttpPost]
        
        public ActionResult create(Teacher t)
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
            if (ModelState.IsValid)
            {
               
                HttpFileCollectionBase file = Request.Files;
                string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file[0].FileName));
                file[0].SaveAs(path);
                t.Photo = "~/images/" + file[0].FileName;
                db.Teachers.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


        }





        public ActionResult edit(int id)
        {
           TeacherDBEntities1 db = new TeacherDBEntities1();
            Teacher existingTeacher = db.Teachers.Where(temp => temp.teacherId == id).FirstOrDefault();
            ViewBag.Departments = db.Departments.ToList();
            

            
            return View(existingTeacher);
        }
      
        [HttpPost]

        public ActionResult edit(Teacher t)
        {
            TeacherDBEntities1 db = new TeacherDBEntities1();
          
            Teacher existingTeacher = db.Teachers.Where(temp => temp.teacherId == t.teacherId).FirstOrDefault();
            existingTeacher.teacherName = t.teacherName;
            existingTeacher.Email = t.Email;
            existingTeacher.PhoneNo = t.PhoneNo;
            existingTeacher.DateOfJoining = t.DateOfJoining;
            existingTeacher.Address = t.Address;
            existingTeacher.DeptId = t.DeptId;
            HttpFileCollectionBase file = Request.Files;
            string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file[0].FileName));
            file[0].SaveAs(path);
            t.Photo = "~/images/" + file[0].FileName;
            existingTeacher.Photo = t.Photo;
           /* ViewBag.pic = t.Photo;*/
            db.Update(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }







            public JsonResult delete(int id)
        {
            bool result = false;
            TeacherDBEntities1 db = new TeacherDBEntities1();
           
            Teacher tr = db.Teachers.Where(temp => temp.teacherId == id).FirstOrDefault();
            db.Teachers.Remove(tr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}