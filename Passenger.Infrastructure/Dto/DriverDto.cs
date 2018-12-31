using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Dto
{
	public class DriverDto
	{
		public Guid UserId { get; set; }
		public string Name { get; set; }
		public VehicleDto Vehicle { get; set; }
		public IEnumerable<RouteDto> Routes { get; set; }
		public IEnumerable<DailyRouteDto> DailyRoutes { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
