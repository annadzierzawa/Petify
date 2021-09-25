using Microsoft.AspNetCore.Mvc;

namespace Petify.Web.Infrastructure
{
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            Content = script;
            ContentType = "application/javascript";
        }
    }
}
