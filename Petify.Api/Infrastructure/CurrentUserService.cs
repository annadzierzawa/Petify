using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Petify.Common.Auth;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Api.Infrastructure
{
    public class CurrentUserService : ICurrentUserService
    {
        private const string isActiveClaim = "is_active";

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Subject)?.Value;

            if (UserId is not null)
            {
                var permissionClaims = httpContextAccessor.HttpContext?.User.Claims
                    .Where(x => x.Type == "allowed_actions")
                    .Select(x => x.Value);

                foreach (var permissionClaim in permissionClaims)
                {
                    Enum.TryParse(permissionClaim.Split(":")[0], true, out Actions action);
                    var policyRequiredLevel = new AccessLevel(permissionClaim.Split(":")[1]);
                    if (!Permissions.ContainsKey(action))
                    {
                        Permissions.Add(action, policyRequiredLevel);
                    }
                }

                IsActive = bool.Parse(httpContextAccessor.HttpContext?.User.Claims
                   .First(x => x.Type == isActiveClaim).Value);
            }
        }

        public string UserId { get; }
        public Dictionary<Actions, AccessLevel> Permissions { get; } = new();

        public bool IsActive { get; } = false;
    }
}
