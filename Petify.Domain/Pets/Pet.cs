using System;
using Petify.Domain.Common;

namespace Petify.Domain.Pets
{
    public class Pet : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
