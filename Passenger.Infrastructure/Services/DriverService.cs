using Passenger.Core.Repositories;
using Passenger.Infrastructure.Dto;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class DriverService : IDriverService
	{
		private readonly IDriverRepository _driverRepository;

		public DriverService(IDriverRepository driverRepository)
		{
			_driverRepository = driverRepository;
		}

		public async Task<DriverDto> Get(Guid userId)
		{
			var driver = await _driverRepository.Get(userId);

			return new DriverDto
			{
				UserId = driver.UserId,
				Vehicle = driver.Vehicle,
				DailyRoutes = driver.DailyRoutes,
				Routes = driver.Routes
			};
		}
	}
}
