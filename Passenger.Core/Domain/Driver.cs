using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
	public sealed class Driver
	{
		private readonly ISet<Route> _routes = new HashSet<Route>();
		private readonly ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();

		public Guid UserId { get; private set; }
		public string Name { get; private set; }
		public Vehicle Vehicle { get; private set; }
		public IEnumerable<Route> Routes => _routes;
		public IEnumerable<DailyRoute> DailyRoutes => _dailyRoutes;
		public DateTime UpdatedAt { get; private set; }

		private Driver() { }

		public Driver(User user)
		{
			UserId = user.Id;
			Name = user.Username;
		}

		public void SetVehicle(Vehicle vehicle)
		{
			Vehicle = vehicle;
			UpdatedAt = DateTime.UtcNow;
		}

		public void AddRoute(string name, Node start, Node end, double distance)
		{
			var route = _routes.SingleOrDefault(r => r.Name == name);
			if (route != null)
				throw new InvalidOperationException($"Route with name '{name}' already exists for driver: {Name}.");

			if (distance < 0)
				throw new InvalidOperationException($"Route with name '{name}' cannot have negative distance.");

			_routes.Add(Route.Create(name, start, end, distance));
			UpdatedAt = DateTime.UtcNow;
		}

		public void RemoveRoute(string name)
		{
			var route = _routes.SingleOrDefault(r => r.Name == name);
			if (route == null)
				throw new InvalidOperationException($"Route with name '{name}' for driver: {Name} was not found.");

			_routes.Remove(route);
			UpdatedAt = DateTime.UtcNow;
		}
	}
}
