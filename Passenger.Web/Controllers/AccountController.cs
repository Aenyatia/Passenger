using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly ICommandDispatcher _commandDispatcher;

		public AccountController(ICommandDispatcher commandDispatcher)
		{
			_commandDispatcher = commandDispatcher;
		}

		[HttpPut("password")]
		public async Task<IActionResult> Put(ChangeUserPassword command)
		{
			await _commandDispatcher.Dispatch(command);

			return NoContent();
		}
	}
}
