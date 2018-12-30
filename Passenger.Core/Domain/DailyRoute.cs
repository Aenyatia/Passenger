using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
	public sealed class DailyRoute
	{
		private readonly ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();

		public Guid Id { get; private set; }
		public Route Route { get; private set; }
		public IEnumerable<PassengerNode> PassengerNodes => _passengerNodes;

		public DailyRoute()
		{
			Id = Guid.NewGuid();
		}

		public void AddPassengerNode(Passenger passenger, Node node)
		{
			var passengerNode = _passengerNodes.SingleOrDefault(pn => pn.Passernger == passenger);
			if (passengerNode != null)
				throw new InvalidOperationException($"Node already exists for passenger '{passenger.UserId}'.");

			_passengerNodes.Add(PassengerNode.Create(passenger, node));
		}

		public void RemovePassengerNode(Passenger passenger)
		{
			var passengerNode = _passengerNodes.SingleOrDefault(pn => pn.Passernger == passenger);
			if (passengerNode == null)
				return;

			_passengerNodes.Remove(passengerNode);
		}
	}
}
