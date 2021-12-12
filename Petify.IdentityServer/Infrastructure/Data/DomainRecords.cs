using Petify.Common.Auth.Access.Lookups;

namespace Petify.IdentityServer.Infrastructure.Data
{
    public record User(string Id, bool IsActive, string PhoneNumber);

    public record UserPermission(string UserId, int ActionId, string ActionName, string Level)
    {
        public override string ToString()
        {
            return $"{(Actions)ActionId}:{Level}";
        }
    };
}
