using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Extensions
{
	public static class RepositoryExtensions
	{
		public static async Task<Driver> GetOrFail(this IDriverRepository repository, Guid userId)
		{
			var driver = await repository.Get(userId);
			if (driver == null)
				throw new ServiceException(ServiceCode.DriverNotFound, $"Driver with Id: '{userId}' was not found.");

			return driver;
		}

		public static async Task<User> GetOrFail(this IUserRepository repository, Guid userId)
		{
			var user = await repository.Get(userId);
			if (user == null)
				throw new ServiceException(ServiceCode.UserNotFound, $"User with Id: '{userId}' was not found.");

			return user;
		}
	}
}
