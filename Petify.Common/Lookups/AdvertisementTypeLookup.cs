using System.Collections.Generic;

namespace Petify.Common.Lookups
{
    public class AdvertisementTypeLookup
    {
        public static Dictionary<int, string> Descriptions = new()
        {
            { (int)AdvertisementTypeEnum.Adoption, "Adoption" },
            { (int)AdvertisementTypeEnum.CyclicalAssistance, "CyclicalAssistance" },
            { (int)AdvertisementTypeEnum.OneTimeHelp, "OneTimeHelp" },
            { (int)AdvertisementTypeEnum.TemporaryAdoption, "TemporaryAdoption" }
        };

        public enum AdvertisementTypeEnum
        {
            Adoption = 1,
            CyclicalAssistance = 2,
            OneTimeHelp = 3,
            TemporaryAdoption = 4
        }
    }
}
