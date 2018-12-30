using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DriversController : ControllerBase
	{
		private readonly IDriverService _driverService;

		public DriversController(IDriverService driverService)
		{
			_driverService = driverService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(Guid userId)
		{
			return Ok(await _driverService.Get(userId));
		}
	}
}
