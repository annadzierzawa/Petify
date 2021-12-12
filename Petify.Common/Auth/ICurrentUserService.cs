using System.Collections.Generic;
using Petify.Common.Auth.Access.Lookups;

namespace Petify.Common.Auth
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsActive { get; }
        Dictionary<Actions, AccessLevel> Permissions { get; }
    }
}
