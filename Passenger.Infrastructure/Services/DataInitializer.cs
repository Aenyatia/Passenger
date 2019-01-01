using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class DataInitializer : IDataInitializer
	{
		private readonly IUserService _userService;
		private readonly IDriverService _driverService;
		private readonly IDriverRouteService _driverRouteService;
		private readonly ILogger<DataInitializer> _logger;

		public DataInitializer(IUserService userService, IDriverService driverService,
			IDriverRouteService driverRouteService, ILogger<DataInitializer> logger)
		{
			_userService = userService;
			_driverService = driverService;
			_driverRouteService = driverRouteService;
			_logger = logger;
		}

		public async Task Seed()
		{
			var users = await _userService.GetAll();
			if (users.Any())
				return;

			_logger.LogTrace("Initializing data...");

			for (var i = 1; i <= 10; i++)
			{
				var userId = Guid.NewGuid();
				var username = $"user{i}";

				_logger.LogInformation($"Created new user: '{username}'.");
				await _userService.Register(userId, $"{username}@example.com", username, "secreD1", "user");

				_logger.LogCritical($"Created driver id: '{userId}'.");
				await _driverService.Create(userId);
				await _driverService.SetVehicle(userId, "BMW", "i8");

				_logger.LogDebug($"Adding route for: '{username}'.");
				await _driverRouteService.Add(userId, "Default", 1, 1, 1, 1);
				await _driverRouteService.Add(userId, "Work route", 1, 2, 3, 4);
			}
			for (var i = 1; i <= 3; i++)
			{
				var userId = Guid.NewGuid();
				var username = $"admin{i}";

				_logger.LogWarning($"Created new admin: '{username}'.");
				await _userService.Register(userId, $"{username}@example.com", username, "secreD1", "admin");
			}

			await Task.CompletedTask;
			_logger.LogError("Data was initialized.");
		}
	}
}
