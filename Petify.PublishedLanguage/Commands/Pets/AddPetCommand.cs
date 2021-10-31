using System;
using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Pets
{
    public class AddPetCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
    }
}
