using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Advertisements
{
    public class RemoveAdvertisementCommand : ICommand
    {
        public int Id { get; set; }
    }
}
