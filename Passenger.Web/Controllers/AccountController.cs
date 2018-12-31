using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IJwtHandler _jwtHandler;

		public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler)
		{
			_commandDispatcher = commandDispatcher;
			_jwtHandler = jwtHandler;
		}

		[HttpGet("token")]
		public IActionResult Get()
		{
			var token = _jwtHandler.CreateToken(Guid.NewGuid(), "admin");

			return Ok(token);
		}

		[HttpGet("auth")]
		[Authorize(Policy = "MustBeAdmin")]
		public IActionResult GetAuth()
		{
			return Ok("Authorized.");
		}

		[HttpPut("password")]
		public async Task<IActionResult> Put(ChangeUserPassword command)
		{
			await _commandDispatcher.Dispatch(command);

			return NoContent();
		}
	}
}
