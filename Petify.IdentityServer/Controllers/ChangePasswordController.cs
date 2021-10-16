using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Petify.IdentityServer.Infrastructure.Data;
using Petify.IdentityServer.Infrastructure.URLs;
using Petify.IdentityServer.Models;

namespace Petify.IdentityServer.Controllers
{
    [Authorize]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IOptions<AppWebSettings> _appWebSettings;

        public ChangePasswordController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<ChangePasswordController> logger,
            IOptions<AppWebSettings> appWebSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appWebSettings = appWebSettings;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            var model = new ChangePasswordViewModel
            {
                ReturnUrl = _appWebSettings.Value.ClientUrl
            };

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ChangePasswordViewModel model, string button)
        {
            if (button == "cancel")
            {
                return Redirect(_appWebSettings.Value.ClientUrl);

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await GetUser();

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    _logger.Log(LogLevel.Error, $"An error occurs when User with ID '{user.Id}' was trying to change password. (Error: '${string.Join(",", changePasswordResult.Errors.Select(e => e.Description))}')");
                    model.HasError = true;
                    return View(model);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                return Redirect(!string.IsNullOrEmpty(model.ReturnUrl)
                    ? model.ReturnUrl + $"?resultCode={ResultCode.PasswordChanged}"
                    : "~/");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel()
        {
            return Redirect(_appWebSettings.Value.ClientUrl);
        }
        private async Task<AppUser> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return user;
        }
    }
}
