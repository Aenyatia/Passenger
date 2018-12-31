using System;

namespace Passenger.Core.Domain
{
	public sealed class Route
	{
		public Guid Id { get; private set; }
		public Node StartNode { get; private set; }
		public Node EndNode { get; private set; }
		public string Name { get; private set; }
		public double Distance { get; private set; }

		private Route(string name, Node startNode, Node endNode, double distance)
		{
			Name = name;
			StartNode = startNode;
			EndNode = endNode;
			Distance = distance;
		}

		public static Route Create(string name, Node start, Node end, double distance)
			=> new Route(name, start, end, distance);
	}
}
