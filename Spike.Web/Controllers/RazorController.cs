namespace Spike.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    public class RazorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentDelivery()
        {
            var model = new ContentDeliveryModel
            {
                PageName = "MVC Content Delivery",
                SectionTitle = "Methods of content delivery",
                Methods = new List<Method>()
                {
                    new Method { Name = "Page Load" },
                    new Method { Name = "AJAX JSon" },
                    new Method { Name = "AJAX HTML" },
                }
            };
            
            return View(model);
        }

        public JsonResult GetJsonData()
        {
            var model = new ContentDeliveryModel
            {
                PageName = "MVC Content Delivery Updated",
                SectionTitle = "Methods of content delivery Updated",
                Methods = new List<Method>()
                {
                    new Method { Name = "Page Load 2" },
                    new Method { Name = "AJAX JSon 2" },
                    new Method { Name = "AJAX HTML 2" },
                }
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}