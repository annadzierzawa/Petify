using System.Collections.Generic;

namespace Petify.Common.Auth.Access.Lookups
{
    public enum Actions
    {
        ManageMyAdvertisements = 1,
        ManageMyPets,
        ManageUsers,
        ManageUsersAdvertisements
    }

    public static class ActionLookup
    {
        public static Dictionary<int, string> Descriptions = new()
        {
            { (int)Actions.ManageMyAdvertisements, "ManageMyAdvertisements" },
            { (int)Actions.ManageMyPets, "ManageMyPets" },
            { (int)Actions.ManageUsers, "ManageUsers" },
            { (int)Actions.ManageUsersAdvertisements, "ManageUsersAdvertisements" }
        };
    }
}
