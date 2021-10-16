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
using Petify.Infrastructure.DataModel.Context;

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
            var domainUserData = _petifyContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            var domainUserData = domainUserData.IsActive;
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
            claims.Add(new Claim(CustomClaims.IsActive, domainUserData.IsActive.ToString(), ClaimValueTypes.Boolean));
            claims.Add(new Claim(CustomClaims.CompanyId, domainUserData.CompanyId.ToString(), ClaimValueTypes.Integer64));
            claims.Add(new Claim(CustomClaims.AnalyticsId, domainUserData.AnalyticsId));

            claims.AddRange(GetAllowedActions(user).Select(allowedAction => new Claim(CustomClaims.AllowedActions, allowedAction.ToString())));

            context.IssuedClaims = claims;
        }

        private IEnumerable<UserPermission> GetAllowedActions(AppUser user)
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
