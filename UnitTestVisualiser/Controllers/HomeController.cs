using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestReflector.Core;


namespace UnitTestVisualiser.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
           
        }

        public JsonResult GetTestData()
        {
            var classes = new List<ClassUnderTest>();
            var cut = new ClassUnderTest();
            cut.ClassName = "Customer";
            cut.ClassDescription = "ABC";
            cut.PublicMethods = new List<string>();
            cut.PublicProperties = new List<string>();
            cut.PublicMethods.Add("Foo()");
            cut.PublicMethods.Add("Bar()");
            cut.PublicMethods.Add("Buzz()");
            cut.PublicMethods.Add("Foo()");
            cut.PublicMethods.Add("Bar()");
            cut.PublicMethods.Add("Buzz()");
            classes.Add(cut);

            //var classes = UtReflector.Get();
            return new JsonResult { Data = classes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
