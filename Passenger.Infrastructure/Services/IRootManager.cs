using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IRootManager : IService
	{
		Task<string> GetAddress(double latitude, double longitude);
		double CalculateDistance(double startLatitude, double endLatitude, double startLongitude, double endLongitude);
	}
}
