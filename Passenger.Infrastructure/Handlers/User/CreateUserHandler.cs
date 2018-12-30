using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.User
{
	public class CreateUserHandler : ICommandHandler<CreateUser>
	{
		private readonly IUserService _userService;

		public CreateUserHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task Handle(CreateUser command)
		{
			await _userService.Register(command.Email, command.Username, command.Password);
		}
	}
}
