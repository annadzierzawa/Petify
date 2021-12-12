using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Users
{
    public class UpdateAccountSettingsCommand : ICommand
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
