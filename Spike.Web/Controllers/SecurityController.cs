namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using App_Data;
    using Models;

    public class SecurityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrossSiteScripting()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return View(model);
        }

        public ActionResult CrossSiteScriptingAllowed()
        {
            return View();
        }

        public ActionResult CrossSiteScriptingNotAllowed()
        {
            return View();
        }

        public JsonResult GetDangerousCode()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDangerousReplacementCode()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return PartialView("_DangerousReplacement", model);
        }
        
        public ActionResult CrossFrameScripting()
        {
            return View();
        }
    }
}