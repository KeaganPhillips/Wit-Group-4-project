using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestReflector.Core;
using ReportManagement;


namespace UnitTestVisualiser.Controllers
{
    using UnitTestVisualiser.Models;

    public class HomeController :PdfViewController //Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
           
        }

        
        public JsonResult GetTestData()
        {
            /*
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
            cut.PublicProperties.Add("try");
            cut.PublicProperties.Add("try2");
            classes.Add(cut);
            */
            var classes = UtReflector.Get();
            return new JsonResult { Data = classes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
        public ActionResult PrintItems()
        {
            var data = UtReflector.Get();
            return this.ViewPdf("Test Scenario Report", "PrintReport", data);
           // return this.ViewPdf("Items report", "PrintReport", CreateItemsList());
        }

        
    }
}
