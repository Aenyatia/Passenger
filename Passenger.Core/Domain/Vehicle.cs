namespace Passenger.Core.Domain
{
	public sealed class Vehicle
	{
		public string Brand { get; private set; }
		public string Model { get; private set; }
		public int Seats { get; private set; }

		public Vehicle()
		{
			
		}
	}
}
