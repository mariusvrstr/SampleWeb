
namespace Spike.Web.App_Data
{
    using System;
    using Instrumentation;
    using System.Web;

    public static class ErrorWriter
    {
        public static IHtmlString Error(Exception ex)
        {
            return new HtmlString(Logging.Error(ex.Message).ToString());
        }
    }
}

