using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
	public sealed class Driver
	{
		public Guid UserId { get; private set; }
		public string Name { get; private set; }
		public Vehicle Vehicle { get; private set; }
		public IEnumerable<Route> Routes { get; private set; }
		public IEnumerable<DailyRoute> DailyRoutes { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		public Driver(User user)
		{
			UserId = user.Id;
			Name = user.Username;
		}

		public void SetVehicle(Vehicle vehicle)
		{
			Vehicle = vehicle;
			UpdatedAt = DateTime.UtcNow;
		}
	}
}
