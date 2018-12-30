using Passenger.Core.Domain;
using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Dto
{
	public class DriverDto
	{
		public Guid UserId { get; set; }
		public Vehicle Vehicle { get; set; }
		public IEnumerable<Route> Routes { get; set; }
		public IEnumerable<DailyRoute> DailyRoutes { get; set; }
	}
}
