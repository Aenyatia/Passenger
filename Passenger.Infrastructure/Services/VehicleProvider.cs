using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class VehicleProvider : IVehicleProvider
	{
		private const string CacheKey = "vehicles";
		private static readonly IDictionary<string, IEnumerable<VehicleDetails>> AvailableVehicles =
			new Dictionary<string, IEnumerable<VehicleDetails>>
			{
				["Audi"] = new List<VehicleDetails>
				{
					new VehicleDetails("RS8", 5)
				},
				["BMW"] = new List<VehicleDetails>
				{
					new VehicleDetails("i8", 3),
					new VehicleDetails("E36", 5)
				},
				["Skoda"] = new List<VehicleDetails>
				{
					new VehicleDetails("Fabia", 5),
					new VehicleDetails("Rapid", 2)
				},
				["Volkswagen"] = new List<VehicleDetails>
				{
					new VehicleDetails("Passat", 4)
				}
			};

		private readonly IMemoryCache _memoryCache;

		public VehicleProvider(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public async Task<IEnumerable<VehicleDto>> GetAll()
		{
			var vehicles = _memoryCache.Get<IEnumerable<VehicleDto>>(CacheKey);
			if (vehicles == null)
			{
				Console.WriteLine("Getting vehicles from database.");

				vehicles = await GetAvailableVehicles();
				_memoryCache.Set(CacheKey, vehicles);
			}
			else
			{
				Console.WriteLine("Getting vehicles from cache.");
			}

			return vehicles;
		}

		public async Task<VehicleDto> Get(string brand, string model)
		{
			if (AvailableVehicles.ContainsKey(brand))
				throw new ArgumentException($"Vehicle brand '{brand}' is not available.");

			var vehicles = AvailableVehicles[brand];
			var vehicle = vehicles.SingleOrDefault(x => x.Model == model);
			if (vehicle == null)
				throw new ArgumentException($"Vehicle model '{model}' for brand '{brand}' is not available.");

			return new VehicleDto
			{
				Brand = brand,
				Model = model,
				Seats = vehicle.Seats
			};
		}

		private async Task<IEnumerable<VehicleDto>> GetAvailableVehicles()
		{
			return AvailableVehicles.GroupBy(d => d.Key)
				.SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDto
				{
					Brand = v.Key,
					Model = c.Model,
					Seats = c.Seats
				})));
		}

		private class VehicleDetails
		{
			public string Model { get; }
			public int Seats { get; }

			public VehicleDetails(string model, int seats)
			{
				Model = model;
				Seats = seats;
			}
		}
	}
}
