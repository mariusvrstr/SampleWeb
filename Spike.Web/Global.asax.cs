namespace Spike.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System;
    using System.Web.Helpers;
    using Instrumentation;

    public class MvcApplication : HttpApplication
    {
        private readonly Logging _logger = LogFactory.Create();

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var errorToken = _logger.ErrorWithRef("Application Error", exception.ToString());

            Response.Clear();
            Server.ClearError();

            var isAjaxCall = string.Equals("XMLHttpRequest", Context.Request.Headers["x-requested-with"], StringComparison.OrdinalIgnoreCase);

            if (isAjaxCall)
            {
                Response.Clear();
                Response.TrySkipIisCustomErrors = true;
                Response.ContentType = "application/json";
                Response.StatusCode = 500;
                Response.StatusDescription = exception.Message;

                var jsonResponse = Json.Encode(new
                {
                    Url = string.Format("{0}Error/ApplicationError?token={1}", BaseSiteUrl, errorToken)
                });

                Response.Write(jsonResponse);
                Response.End();
            }
            else
            {
                Response.Redirect(string.Format("{0}Error/ApplicationError?token={1}", BaseSiteUrl, errorToken));
            }
        }
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected static string BaseSiteUrl
        {
            get
            {
                var context = HttpContext.Current;
                if (context.Request.ApplicationPath == null) return string.Empty;
                var baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
                return baseUrl;
            }
        }
    }
}
