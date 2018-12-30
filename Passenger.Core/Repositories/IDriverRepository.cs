using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
	public interface IDriverRepository
	{
		Task<Driver> Get(Guid userId);
		Task<IEnumerable<Driver>> GetAll();

		Task Add(Driver driver);
		Task Update(Driver driver);
		Task Delete(Guid userId);
	}
}
