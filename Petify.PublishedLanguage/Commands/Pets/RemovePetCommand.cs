using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Pets
{
    public class RemovePetCommand : ICommand
    {
        public int Id { get; set; }
    }
}
