using System.Threading.Tasks;
using Passenger.Infrastructure.Dto;

namespace Passenger.Infrastructure.Services
{
	public interface IUserService
	{
		Task<UserDto> Get(string email);

		Task Register(string email, string username, string password);
	}
}
