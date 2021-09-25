using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands
{
    public class AddSampleCommand : ICommand
    {
        public string Name { get; set; }
    }
}
