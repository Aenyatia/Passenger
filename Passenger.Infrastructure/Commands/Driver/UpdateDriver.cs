using Passenger.Infrastructure.Commands.Driver.Models;
using System;

namespace Passenger.Infrastructure.Commands.Driver
{
	public class UpdateDriver : IAuthenticatedCommand
	{
		public Guid UserId { get; set; }
		public DriverVehicle Vehicle { get; set; }
	}
}
