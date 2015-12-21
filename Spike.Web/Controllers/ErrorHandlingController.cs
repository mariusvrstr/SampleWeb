namespace Spike.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    public class ErrorHandlingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThrowUnexpectedException()
        {
            throw new ArgumentException();
        }

        public ActionResult GenericError()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;

            return View("PageNotFound");
        }
    }
}