namespace Passenger.Infrastructure.Dto
{
	public class RouteDto
	{
		public string Name { get; set; }
		public NodeDto StartNode { get; set; }
		public NodeDto EndNode { get; set; }
	}
}
