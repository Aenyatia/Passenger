using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;
using Passenger.Infrastructure.Commands.User;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
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
		public async Task<IActionResult> Post(CreateUser command)
		{
			await _userService.Register(command.Email, command.Username, command.Password);

			return Created($"users/{command.Email}", null);
		}
	}
}
