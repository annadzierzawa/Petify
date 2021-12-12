using Microsoft.AspNetCore.Authorization;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access
{
    public class RequireAccessLevelRequirement : IAuthorizationRequirement
    {
        public RequireAccessLevelRequirement(Actions action, AccessLevel requiredAccessLevel)
        {
            Action = action;
            RequiredAccessLevel = requiredAccessLevel;
        }

        public Actions Action { get; }
        public AccessLevel RequiredAccessLevel { get; }
    }
}
