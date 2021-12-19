using System;
using Petify.Domain.Pets;
using Shouldly;
using Xunit;

namespace Petify.Domain.Tests
{
    public class PetTests
    {
        [Fact]
        public void Pet_WhenUpdateFieldsIsCalled_ThenFieldsAreSetProperly()
        {
            //given
            Pet pet = new Pet("pet", 1, DateTime.Today, "desc", "dadsada");

            //when
            pet.UpdateFields("NewName", 4, new DateTime(2020, 1, 1), "NewDescription");

            //then
            pet.Name.ShouldBe("NewName");
            pet.Description.ShouldBe("NewDescription");
            pet.SpeciesId.ShouldBe(4);
            pet.DateOfBirth.ShouldBe(new DateTime(2020, 1, 1));
        }
    }
}
