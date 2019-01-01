using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
	public class DriverRepository : IDriverRepository
	{
		private static readonly ISet<Driver> Drivers = new HashSet<Driver>();

		public async Task<Driver> Get(Guid userId)
		{
			return Drivers.SingleOrDefault(d => d.UserId == userId);
		}

		public async Task<IEnumerable<Driver>> GetAll()
		{
			return Drivers.ToList();
		}

		public async Task Add(Driver driver)
		{
			Drivers.Add(driver);
		}

		public async Task Update(Driver driver)
		{

		}

		public async Task Delete(Driver driver)
		{
			Drivers.Remove(driver);
		}
	}
}
