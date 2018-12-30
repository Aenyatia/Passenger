namespace Passenger.Core.Domain
{
	public sealed class Node
	{
		public string Address { get; private set; }
		public double Longitude { get; private set; }
		public double Latitude { get; private set; }

		public Node()
		{
			
		}
	}
}
