using System;

namespace Passenger.Core.Domain
{
	public sealed class Passenger
	{
		public Guid Id { get; private set; }
		public Guid UserId { get; private set; }
		public Node Address { get; private set; }
	}
}
