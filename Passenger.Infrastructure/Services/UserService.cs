using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Dto;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Passenger.Infrastructure.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UserDto> Get(string email)
		{
			var user = await _userRepository.Get(email);

			return _mapper.Map<User, UserDto>(user);
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
