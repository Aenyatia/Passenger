using System;

namespace Passenger.Infrastructure.Commands.Driver
{
	public class DeleteDriver : IAuthenticatedCommand
	{
		public Guid UserId { get; set; }
	}
}
