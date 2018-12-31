using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private static readonly ISet<User> Users = new HashSet<User>
		{
			new User("user1@example.com", "secreD1", "salt", "user1", "user"),
			new User("user2@example.com", "secreD1", "salt", "user2", "admin"),
			new User("user3@example.com", "secreD1", "salt", "user3", "user")
		};

		public async Task<User> Get(Guid id)
		{
			return Users.SingleOrDefault(u => u.Id == id);
		}

		public async Task<User> Get(string email)
		{
			return Users.SingleOrDefault(u => u.Email == email.ToLowerInvariant());
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return Users.ToList();
		}

		public async Task Add(User user)
		{
			Users.Add(user);
		}

		public async Task Update(User user)
		{
			throw new NotImplementedException();
		}

		public async Task Remove(Guid id)
		{
			var user = await Get(id);
			Users.Remove(user);
		}
	}
}
