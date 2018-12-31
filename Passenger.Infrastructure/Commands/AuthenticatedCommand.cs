using System;

namespace Passenger.Infrastructure.Commands
{
	public class AuthenticatedCommand : IAuthenticatedCommand
	{
		public Guid UserId { get; set; }
	}
}
