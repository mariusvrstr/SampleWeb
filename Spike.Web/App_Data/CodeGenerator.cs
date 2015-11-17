
namespace Spike.Web
{
    using System;
    
    public static class CodeGenerator
    {
	    public static string GetDangerouseSqlString()
	    {
            return "(SELECT top 1 ''Server Version'' + CONVERT(varchar(100), SERVERPROPERTY(''productversion'')))";
	    }

        public static string GetDangerouseHtmlString()
        {
            return @"<input type='button' value='Injected Button' onclick='javascript:alert(""Cross Site Attacked!"")' />";
        }

        public static string GetDangerouseJavaScriptString()
        {
            return "<script>alert('Cross Site Attacked!')</script>";
        }
    }
}

