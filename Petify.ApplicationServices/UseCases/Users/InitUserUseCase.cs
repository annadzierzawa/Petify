using System.Net.Mail;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.PublishedLanguage.Commands.Users;

namespace Petify.ApplicationServices.UseCases.Users
{
    public class InitUserUseCase : ICommandHandler<InitUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InitUserUseCase(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(InitUserCommand command)
        {
            Domain.Access.User newUser = new(command.UserId, new MailAddress(command.Email), command.Name, command.PhoneNumber);

            await _usersRepository.Store(newUser);

            await _unitOfWork.Save();
        }
    }
}
