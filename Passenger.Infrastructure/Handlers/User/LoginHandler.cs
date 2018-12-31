using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.User
{
	public class LoginHandler : ICommandHandler<Login>
	{
		private readonly IUserService _userService;
		private readonly IJwtHandler _jwtHandler;
		private readonly IMemoryCache _memoryCache;

		public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
		{
			_userService = userService;
			_jwtHandler = jwtHandler;
			_memoryCache = memoryCache;
		}

		public async Task Handle(Login command)
		{
			await _userService.Login(command.Email, command.Password);
			var user = await _userService.Get(command.Email);
			var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

			_memoryCache.SetJwt(command.TokenId, jwt);
		}
	}
}
