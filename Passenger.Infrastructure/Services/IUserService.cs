﻿using Passenger.Infrastructure.Dto;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IUserService : IService
	{
		Task<UserDto> Get(string email);

		Task Register(string email, string username, string password);
	}
}
