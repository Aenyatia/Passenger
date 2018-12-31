using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using System;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class DriverRoutesController : ControllerBase
	{
		private readonly ICommandDispatcher _commandDispatcher;

		public DriverRoutesController(ICommandDispatcher commandDispatcher)
		{
			_commandDispatcher = commandDispatcher;
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Post(CreateDriverRoute command)
		{
			await DispatchAsync(command);

			return NoContent();
		}

		[Authorize]
		[HttpDelete("{name}")]
		public async Task<IActionResult> Post(string name)
		{
			var command = new DeleteDriverRoute
			{
				Name = name
			};
			await DispatchAsync(command);

			return NoContent();
		}

		private async Task DispatchAsync<T>(T command) where T : ICommand
		{
			if (command is IAuthenticatedCommand authenticatedCommand)
				authenticatedCommand.UserId = GetId();

			await _commandDispatcher.Dispatch(command);
		}

		private Guid GetId()
			=> User?.Identity?.IsAuthenticated == true ? Guid.Parse(User.Identity.Name) : Guid.Empty;
	}
}
