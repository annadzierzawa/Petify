using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Petify.IdentityServer.Infrastructure.Data;

namespace Petify.IdentityServer.Infrastructure.Services
{
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<AppUser> _claimsFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly PetifyContext _petifyContext;

        public IdentityClaimsProfileService(UserManager<AppUser> userManager, IUserClaimsPrincipalFactory<AppUser> claimsFactory, PetifyContext petifyContext)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _petifyContext = petifyContext;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var crmUser = await _petifyContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            var isUserActive = crmUser.IsActive;
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
            claims.Add(new Claim("is_active", isUserActive.ToString(), ClaimValueTypes.Boolean));

            claims.AddRange(GetAllowedActions(user).Select(allowedAction => new Claim("allowed_actions", allowedAction.ToString())));

            context.IssuedClaims = claims;
        }

        private IEnumerable<Domain.Access.UserPermission> GetAllowedActions(AppUser user)
        {
            return _petifyContext.UserPermission.Where(x => x.UserId == user.Id).ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
