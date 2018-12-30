namespace Passenger.Core.Domain
{
	public sealed class PassengerNode
	{
		public Passenger Passernger { get; private set; }
		public Node Node { get; private set; }

		private PassengerNode(Passenger passenger, Node node)
		{
			Passernger = passenger;
			Node = node;
		}

		public static PassengerNode Create(Passenger passenger, Node node)
		{
			return new PassengerNode(passenger, node);
		}
	}
}
