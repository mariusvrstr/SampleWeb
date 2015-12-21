namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class ErrorController : Controller
    {
        public ActionResult ApplicationError(string token)
        {
            var model = new TokenErrorModel
            {
                Token = token
            };

            return View(model);
        }
    }
}