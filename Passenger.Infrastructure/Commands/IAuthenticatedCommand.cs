using Passenger.Infrastructure.CQS.Commands;
using System;

namespace Passenger.Infrastructure.Commands
{
	public interface IAuthenticatedCommand : ICommand
	{
		Guid UserId { get; set; }
	}
}
