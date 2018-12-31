using System;

namespace Passenger.Infrastructure.Commands.Driver
{
	public class CreateDriverRoute : IAuthenticatedCommand
	{
		public Guid UserId { get; set; }
		public string Name { get; set; }
		public double StartLatitude { get; set; }
		public double StartLongitude { get; set; }
		public double EndLatitude { get; set; }
		public double EndLongitude { get; set; }
	}
}
