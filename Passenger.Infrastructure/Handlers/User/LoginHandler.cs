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
		private readonly IHandler _handler;

		public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache, IHandler handler)
		{
			_userService = userService;
			_jwtHandler = jwtHandler;
			_memoryCache = memoryCache;
			_handler = handler;
		}

		public async Task Handle(Login command)
		{
			await _handler.Run(async () => await _userService.Login(command.Email, command.Password))
				.Next()
				.Run(async () =>
				{
					var user = await _userService.Get(command.Email);
					var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

					_memoryCache.SetJwt(command.TokenId, jwt);
				})
				.ExecuteAsync();
		}
	}
}
