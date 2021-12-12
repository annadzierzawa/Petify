using System;
using Microsoft.AspNetCore.Authorization;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RequireAccessLevelAttribute : AuthorizeAttribute
    {
        public RequireAccessLevelAttribute(Actions action, AccessLevel accessLevel)
            : base($"{action}:{accessLevel.Id}")
        {
        }
    }
}
