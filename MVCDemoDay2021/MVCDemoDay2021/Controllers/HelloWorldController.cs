using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemoDay2021.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int age = 0)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.Age = age;

            return View();
        }


        // public string Index()
        // {
        //    return "<h3> Hello index route </h3>";
        // }

        //public string Welcome( string name, int age=0)
        //{
        //    string msg;
        //    if (age > 0)
        //    {
        //        msg = HttpUtility.HtmlEncode("hello " + name + " your age is " + age);
        //    }
        //    else
        //    {
        //        msg = HttpUtility.HtmlEncode("hello " + name + " your age is not important");
        //    }
        //    return "<h3>" + msg + "</h3>";
        //}
    }
}