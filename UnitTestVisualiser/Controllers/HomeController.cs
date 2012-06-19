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
            return this.ViewPdf("Items report", "PrintReport", data);
           // return this.ViewPdf("Items report", "PrintReport", CreateItemsList());
        }

        private ItemstoDisplayList CreateItemsList()
        {
            return new ItemstoDisplayList()
                {
                    new Item { Id = 1, Name = "Patrick", Address = "Geuzenstraat 29", Place = "Amsterdam" },
                    new Item { Id = 2, Name = "Fred", Address = "Flink 9a", Place = "Rotterdam" },                    
                    new Item { Id = 21, Name = "Schimmelmann", Address = "Ritzema Bosstraat 28-2", Place = "Vierenman" },
                    new Item { Id = 22, Name = "Makhlouf", Address = "Ln vd Helende Meesters 12", Place = "Eindhoven" },
                    new Item { Id = 23, Name = "Meyer", Address = "Burgemeester v Leeuwenln 79H", Place = "Breda" },
                    
                   
                };
        }
    }
}
