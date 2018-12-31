using Passenger.Infrastructure.CQS.Commands;
using System;

namespace Passenger.Infrastructure.Commands.Driver
{
	public class DeleteDriverRoute : ICommand
	{
		public Guid UserId { get; set; }
		public string Name { get; set; }
	}
}
