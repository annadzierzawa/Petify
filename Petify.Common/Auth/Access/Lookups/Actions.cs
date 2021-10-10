using System.Collections.Generic;

namespace Petify.Common.Auth.Access.Lookups
{
    public enum Actions
    {
        Announcements = 1,
        Reviews,
        ManageUsers
    }

    public static class ActionLookup
    {
        public static Dictionary<int, string> Descriptions = new()
        {
            { (int)Actions.Announcements, "Announcements" },
            { (int)Actions.Reviews, "Reviews" },
            { (int)Actions.ManageUsers, "ManageUsers" }
        };
    }
}
