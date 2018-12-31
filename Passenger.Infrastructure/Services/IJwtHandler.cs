using Passenger.Infrastructure.Dto;

namespace Passenger.Infrastructure.Services
{
	public interface IJwtHandler
	{
		JwtDto CreateToken(string email, string role);
	}
}
