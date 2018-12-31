using Passenger.Infrastructure.Dto;
using System;

namespace Passenger.Infrastructure.Services
{
	public interface IJwtHandler
	{
		JwtDto CreateToken(Guid userId, string role);
	}
}
