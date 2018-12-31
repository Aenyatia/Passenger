using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class DriverRouteService : IDriverRouteService
	{
		private readonly IDriverRepository _driverRepository;
		private readonly IRootManager _rootManager;

		public DriverRouteService(IDriverRepository driverRepository, IRootManager rootManager)
		{
			_driverRepository = driverRepository;
			_rootManager = rootManager;
		}

		public async Task Add(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude,
			double endLongitude)
		{
			var driver = await _driverRepository.GetOrFail(userId);

			var startAddress = await _rootManager.GetAddress(startLatitude, startLongitude);
			var startNode = Node.Create(startAddress, startLongitude, startLatitude);

			var endAddress = await _rootManager.GetAddress(endLatitude, endLongitude);
			var end = Node.Create(endAddress, endLongitude, endLatitude);

			var distance = _rootManager.CalculateDistance(startLatitude, endLatitude, startLongitude, endLongitude);

			driver.AddRoute(name, startNode, end, distance);
			await _driverRepository.Update(driver);
		}

		public async Task Delete(Guid userId, string name)
		{
			var driver = await _driverRepository.GetOrFail(userId);

			driver.RemoveRoute(name);
			await _driverRepository.Update(driver);
		}
	}
}
