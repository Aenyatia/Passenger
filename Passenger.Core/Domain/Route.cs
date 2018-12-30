using System;

namespace Passenger.Core.Domain
{
	public sealed class Route
	{
		public Guid Id { get; private set; }
		public Node StartNode { get; private set; }
		public Node EndNode { get; private set; }

		public Route()
		{
			
		}
	}
}
