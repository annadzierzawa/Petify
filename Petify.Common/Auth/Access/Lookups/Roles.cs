using System.Collections.Generic;

namespace Petify.Common.Auth.Access.Lookups
{
    public enum Roles
    {
        Admin = 1,
        RegularUser
    }

    public static class RoleLookup
    {
        public static Dictionary<int, string> Descriptions = new()
        {
            { (int)Roles.Admin, "Admin" },
            { (int)Roles.RegularUser, "RegularUser" }
        };
    }
}