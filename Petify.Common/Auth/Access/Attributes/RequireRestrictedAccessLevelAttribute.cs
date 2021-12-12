using System;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RequireRestrictedAccessLevelAttribute : RequireAccessLevelAttribute
    {
        public RequireRestrictedAccessLevelAttribute(Actions action) : base(action, AccessLevel.Restricted)
        {
        }
    }
}
