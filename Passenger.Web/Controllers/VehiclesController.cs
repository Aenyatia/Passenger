using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class VehiclesController : ControllerBase
	{
		private readonly IVehicleProvider _vehicleProvider;

		public VehiclesController(IVehicleProvider vehicleProvider)
		{
			_vehicleProvider = vehicleProvider;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var vehicles = await _vehicleProvider.GetAll();
			if (vehicles == null)
				return NotFound();

			return Ok(vehicles);
		}
	}
}
