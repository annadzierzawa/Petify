using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access
{
    public class RequireAccessLevelHandler : AuthorizationHandler<RequireAccessLevelRequirement>
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly Dictionary<string, int> _accessLevelToValueMap = new()
        {
            { AccessLevel.None.Id, 0 },
            { AccessLevel.Restricted.Id, 1 },
            { AccessLevel.Full.Id, 2 }
        };

        public RequireAccessLevelHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireAccessLevelRequirement requirement)
        {
            var currentUserPermissions = _currentUserService.Permissions;

            if (!_currentUserService.IsActive)
            {
                context.Fail();
            }

            if (!currentUserPermissions.Any() || !currentUserPermissions.ContainsKey(requirement.Action) || !HasRequiredAccessLevel(currentUserPermissions[requirement.Action], requirement.RequiredAccessLevel))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool HasRequiredAccessLevel(AccessLevel userAccessLevel, AccessLevel requiredAccessLevel)
        {
            return _accessLevelToValueMap[userAccessLevel.Id] >= _accessLevelToValueMap[requiredAccessLevel.Id];
        }
    }
}
