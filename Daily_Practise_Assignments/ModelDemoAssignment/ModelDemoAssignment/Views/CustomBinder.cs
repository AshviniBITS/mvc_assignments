using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelDemoAssignment.Models
{
    public class CustomBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllercontext, ModelBindingContext bindingcontext)
        {
            int StudentId = Convert.ToInt32(controllercontext.HttpContext.Request.Form["StudentId"]);
            string StudentName = controllercontext.HttpContext.Request.Form["StudentName"];
            int Dno = Convert.ToInt32(controllercontext.HttpContext.Request.Form["Dno"]);
            string street = controllercontext.HttpContext.Request.Form["street"];
            string landmark = controllercontext.HttpContext.Request.Form["landmark"];
            string city = controllercontext.HttpContext.Request.Form["city"];
            return new Student() { StudentId = StudentId, StudentName = StudentName, address = Dno + " " + street + " " + landmark + " " + city };



        }
    }
}