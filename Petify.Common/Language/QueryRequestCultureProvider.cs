using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Petify.Common.Language
{
    public class QueryRequestCultureProvider : RequestCultureProvider
    {
        private const string LanguageQuerySegment = "ui_locales";
        private const string ReturnUrlQuerySegment = "returnUrl";

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            string language;

            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            bool isLanguageSegmentExists = httpContext.Request.Query.TryGetValue(LanguageQuerySegment, out var languageSegment);

            if (isLanguageSegmentExists)
            {
                language = languageSegment;
            }
            else
            {
                bool returnUrlSegmentExists = httpContext.Request.Query.TryGetValue(ReturnUrlQuerySegment, out var returnUrlSegment);

                if (!returnUrlSegmentExists)
                {
                    return NullProviderCultureResult;
                }

                var returnUrlQuery = returnUrlSegment.ToArray()
                    .First();

                language = GetLanguage(returnUrlQuery);

                if (string.IsNullOrEmpty(language))
                {
                    return NullProviderCultureResult;
                }
            }

            httpContext.Response.Cookies.Append(LanguageHelper.LanguageTag, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)));

            return Task.FromResult(new ProviderCultureResult(language));
        }

        private string GetLanguage(string returnUrlQuery)
        {
            var queryValues = returnUrlQuery.Split('&').Select(q => q.Split('='))
                .ToDictionary(k => k[0], v => v[1]);

            return queryValues.ContainsKey(LanguageQuerySegment)
                ? queryValues[LanguageQuerySegment]
                : string.Empty;
        }
    }
}
