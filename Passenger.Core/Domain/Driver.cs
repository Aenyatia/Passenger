using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
	public sealed class Driver
	{
		public Guid UserId { get; private set; }
		public Vehicle Vehicle { get; private set; }
		public IEnumerable<Route> Routes { get; private set; }
		public IEnumerable<DailyRoute> DailyRoutes { get; private set; }

		public Driver(Guid userId, Vehicle vehicle)
		{
			UserId = userId;
			Vehicle = vehicle;
		}
	}
}
