using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class RootManager : IRootManager
	{
		private static readonly Random Random = new Random();

		public async Task<string> GetAddress(double latitude, double longitude)
		{
			return $"Sample address {Random.Next(1, 100)}";
		}

		public double CalculateDistance(double startLatitude, double endLatitude, double startLongitude, double endLongitude)
		{
			return Random.Next(500, 10000);
		}
	}
}
