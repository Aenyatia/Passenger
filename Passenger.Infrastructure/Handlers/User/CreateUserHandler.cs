using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.User
{
	public class CreateUserHandler : ICommandHandler<CreateUserCommand>
	{
		private readonly IUserService _userService;

		public CreateUserHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task Handle(CreateUserCommand command)
		{
			await _userService.Register(command.Email, command.Username, command.Password);
		}
	}
}
