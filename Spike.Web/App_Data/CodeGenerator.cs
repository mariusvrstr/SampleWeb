
namespace Spike.Web
{
    using System;
    
    public static class CodeGenerator
    {
	    public static string GetDangerousSqlString()
	    {
            return "(SELECT top 1 ''Server Version'' + CONVERT(varchar(100), SERVERPROPERTY(''productversion'')))";
	    }

        public static string GetDangerousHtmlString()
        {
            return @"<input type='button' value='Injected Button' onclick='javascript:alert(""Cross Site Attacked!"")' />";
        }

        public static string GetDangerousJavaScriptString()
        {
            return "<script>alert('Cross Site Attacked!')</script>";
        }
    }
}

