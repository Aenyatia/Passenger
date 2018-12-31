using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IDriverRouteService : IService
	{
		Task Add(Guid userId, string name,
			double startLatitude, double startLongitude,
			double endLatitude, double endLongitude);

		Task Delete(Guid userId, string name);
	}
}
