using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
	public interface IUserRepository
	{
		Task<User> Get(Guid id);
		Task<User> Get(string email);
		Task<IEnumerable<User>> GetAll();

		Task Add(User user);
		Task Update(User user);
		Task Remove(Guid id);
	}
}
