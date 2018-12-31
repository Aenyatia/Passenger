using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IMemoryCache _memoryCache;

		public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache)
		{
			_commandDispatcher = commandDispatcher;
			_memoryCache = memoryCache;
		}

		[HttpPost]
		public async Task<IActionResult> Post(Login command)
		{
			command.TokenId = Guid.NewGuid();
			await _commandDispatcher.Dispatch(command);

			return Ok(_memoryCache.GetJwt(command.TokenId));
		}
	}
}
