using System;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth.Access.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RequireFullAccessLevelAttribute : RequireAccessLevelAttribute
    {
        public RequireFullAccessLevelAttribute(Actions action) : base(action, AccessLevel.Full)
        {
        }
    }
}
