using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
	public class UserRepositoryEf : IUserRepository, ISqlRepository
	{
		private readonly PassengerContext _context;

		public UserRepositoryEf(PassengerContext context)
		{
			_context = context;
		}

		public async Task<User> Get(Guid id)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User> Get(string email)
		{
			return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task Add(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task Update(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			var user = await Get(id);
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
	}
}
