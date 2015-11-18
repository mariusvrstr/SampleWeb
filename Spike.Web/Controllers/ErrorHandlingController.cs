using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spike.Web.Controllers
{
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