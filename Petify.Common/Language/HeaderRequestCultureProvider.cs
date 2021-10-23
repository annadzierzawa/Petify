using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Petify.Common.Language
{
    public class HeaderRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var languageHeader = httpContext.Request.Headers[LanguageHelper.LanguageTag];

            return languageHeader.Count == 0 ? NullProviderCultureResult : Task.FromResult(new ProviderCultureResult(languageHeader[0]));
        }
    }
}
