using Petify.Common.CQRS;

namespace Petify.PublishedLanguage.Commands.Users
{
    public record InitUserCommand(string UserId, string Email, string Name, string PhoneNumber) : ICommand;
}
