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
			return Ok(await _userService.Get(email));
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateUser command)
		{
			await _userService.Register(command.Email, command.Username, command.Password);

			return Created(string.Empty, null);
		}
	}
}
