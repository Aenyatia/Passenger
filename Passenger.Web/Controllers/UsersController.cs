using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ICommandDispatcher _commandDispatcher;

		public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
		{
			_userService = userService;
			_commandDispatcher = commandDispatcher;
		}

		[HttpGet("{email}")]
		public async Task<IActionResult> Get(string email)
		{
			var user = await _userService.Get(email);
			if (user == null)
				return NotFound();

			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateUserCommand command)
		{
			await _commandDispatcher.Dispatch(command);

			return Created($"users/{command.Email}", null);
		}
	}
}
