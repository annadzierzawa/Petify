using System;
using System.Collections.Generic;
using System.Linq;
using Petify.Domain.Advertisements;
using Petify.Domain.Advertisements.Parameters;
using Petify.Domain.Pets;
using Shouldly;
using Xunit;

namespace Petify.Domain.Tests
{
    public class AdvertisementTests
    {
        [Fact]
        public void Advertisement_WhenSetPetsCalled_ThenPetsAreAdded()
        {
            //given 
            Advertisement advertisement = new Advertisement("title", "description", 1, new List<Pet>(), "ownerId", null, new AdvertisementDatesParameter(DateTime.Today, DateTime.Today), new List<CyclicalAssistanceDay>());
            List<Pet> pets = new List<Pet>()
            {
                new Pet("first",1,DateTime.Today,"desc","dadsada"),
                new Pet("second",1,DateTime.Today,"desc","dadsada")
            };
            //when
            advertisement.SetPets(pets);
            //then
            advertisement.Pets.Count.ShouldBe(2);
        }

        [Fact]
        public void Advertisement_WhenSetPetsCalledWithOneOldAnimalsThen_ThenNewPetAreAddedAndOldStaysOnTheList()
        {
            //given 
            Pet oldPet = new Pet("first", 1, DateTime.Today, "desc", "dadsada");
            oldPet.Id = 1;
            Pet newPet = new Pet("second", 1, DateTime.Today, "desc", "dadsada");
            newPet.Id = 2;
            Advertisement advertisement = new Advertisement("title", "description", 1, new List<Pet>() { oldPet }, "ownerId", null, new AdvertisementDatesParameter(DateTime.Today, DateTime.Today), new List<CyclicalAssistanceDay>());
            List<Pet> pets = new List<Pet>()
            {
                oldPet,
                newPet
            };
            //when
            advertisement.SetPets(pets);
            //then
            advertisement.Pets.Any(p => p.Name == "first").ShouldBeTrue();
            advertisement.Pets.Any(p => p.Name == "second").ShouldBeTrue();
            advertisement.Pets.Count().ShouldBe(2);
        }
    }
}
