using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
	public sealed class DailyRoute
	{
		public Guid Id { get; private set; }
		public Route Route { get; private set; }
		public IEnumerable<PassengerNode> PassengerNodes { get; private set; }

		public DailyRoute()
		{
			
		}
	}
}
