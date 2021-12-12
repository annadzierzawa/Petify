using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Petify.ApplicationServices.Boundaries.Users;
using Petify.Common.Auth.Access.Lookups;
using Petify.Common.CQRS;
using Petify.Domain;
using Petify.Domain.Access;
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
            _usersRepository.StoreUserRoles(new List<UserRole>() { new UserRole() { RoleId = (int)Roles.RegularUser, UserId = command.UserId } });

            await _unitOfWork.Save();
        }
    }
}
