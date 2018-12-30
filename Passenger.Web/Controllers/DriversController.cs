using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class DriversController : ControllerBase
	{
		private readonly IDriverService _driverService;
		private readonly ICommandDispatcher _commandDispatcher;

		public DriversController(IDriverService driverService, ICommandDispatcher commandDispatcher)
		{
			_driverService = driverService;
			_commandDispatcher = commandDispatcher;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> Get(Guid userId)
		{
			var driver = await _driverService.Get(userId);
			if (driver == null)
				return NotFound();

			return Ok(driver);
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateDriver command)
		{
			await _commandDispatcher.Dispatch(command);

			return Created($"drivers/{command.UserId}", null);
		}
	}
}
