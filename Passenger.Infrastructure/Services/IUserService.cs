using Passenger.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IUserService : IService
	{
		Task<UserDto> Get(string email);
		Task<IEnumerable<UserDto>> GetAll();

		Task Login(string email, string password);
		Task Register(Guid id, string email, string username, string password, string role);
	}
}
