
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
                SectionTitel = "Methods of content delivery",
                Methods = new List<Method>()
                {
                    new Method { Name = "Page Load" },
                    new Method { Name = "AJAX JSon" },
                    new Method { Name = "AJAX HTML" },
                }
            };
            
            return View(model);
        }
    }
}