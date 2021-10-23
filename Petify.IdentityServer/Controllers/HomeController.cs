using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Petify.Common.Language;
using Petify.IdentityServer.Infrastructure.URLs;

namespace Petify.IdentityServer.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppWebSettings> _appWebSettings;

        public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger, IOptions<AppWebSettings> appWebSettings)
        {
            _environment = environment;
            _logger = logger;
            _appWebSettings = appWebSettings;
        }

        public IActionResult Index()
        {
            return Redirect(_appWebSettings.Value.ClientUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                LanguageHelper.LanguageTag,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
