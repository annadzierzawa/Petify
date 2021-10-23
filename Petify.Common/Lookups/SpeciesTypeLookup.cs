using System.Collections.Generic;

namespace Petify.Common.Lookups
{
    public class SpeciesTypeLookup
    {
        public static Dictionary<int, string> Descriptions = new()
        {
            { (int)SpeciesTypeEnum.Dog, "Dog" },
            { (int)SpeciesTypeEnum.Cat, "Cat" },
            { (int)SpeciesTypeEnum.Bird, "Bird" },
            { (int)SpeciesTypeEnum.Fish, "Fish" },
            { (int)SpeciesTypeEnum.Horse, "Horse" },
            { (int)SpeciesTypeEnum.Hamster, "Hamster" },
            { (int)SpeciesTypeEnum.GuineaPig, "GuineaPig" },
            { (int)SpeciesTypeEnum.Pig, "Pig" },
            { (int)SpeciesTypeEnum.Meerkat, "Meerkat" },
            { (int)SpeciesTypeEnum.Snake, "Snake" },
            { (int)SpeciesTypeEnum.Rabbit, "Rabbit" },
            { (int)SpeciesTypeEnum.Spider, "Spider" }
        };

        public enum SpeciesTypeEnum
        {
            Dog = 1,
            Cat = 2,
            Hamster = 3,
            Horse = 4,
            Fish = 5,
            GuineaPig = 6,
            Pig = 7,
            Meerkat = 8,
            Snake = 9,
            Rabbit = 10,
            Spider = 11,
            Bird = 12
        }
    }
}
