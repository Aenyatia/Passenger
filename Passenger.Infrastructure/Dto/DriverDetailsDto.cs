using System.Collections.Generic;

namespace Passenger.Infrastructure.Dto
{
	public class DriverDetailsDto : DriverDto
	{
		public IEnumerable<RouteDto> Routes { get; set; }
		//public IEnumerable<DailyRouteDto> DailyRoutes { get; set; }
	}
}
