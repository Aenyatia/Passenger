using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository, IMongoRepository
	{
		private readonly IMongoDatabase _mongoDatabase;

		public UserRepository(IMongoDatabase mongoDatabase)
		{
			_mongoDatabase = mongoDatabase;
		}

		public async Task<User> Get(Guid id)
		{
			return await Users.AsQueryable().SingleOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User> Get(string email)
		{
			return await Users.AsQueryable().SingleOrDefaultAsync(u => u.Email == email.ToLowerInvariant());
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await Users.AsQueryable().ToListAsync();
		}

		public async Task Add(User user)
		{
			await Users.InsertOneAsync(user);
		}

		public async Task Update(User user)
		{
			await Users.ReplaceOneAsync(u => u.Id == user.Id, user);
		}

		public async Task Remove(Guid id)
		{
			await Users.DeleteOneAsync(u => u.Id == id);
		}

		private IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("Users");
	}
}
