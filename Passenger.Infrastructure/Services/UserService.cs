using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Dto;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> Get(string email)
		{
			var user = await _userRepository.Get(email);

			return new UserDto
			{
				Id = user.Id,
				Username = user.Username,
				Email = user.Email,
				FullName = user.FullName
			};
		}

		public async Task Register(string email, string username, string password)
		{
			var user = await _userRepository.Get(email);
			if (user != null)
				throw new InvalidOperationException($"User with email '{email}' already exists.");

			var salt = Guid.NewGuid().ToString();
			user = new User(email, password, salt, username);
			await _userRepository.Add(user);
		}
	}
}
