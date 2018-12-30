using Passenger.Infrastructure.Dto;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IDriverService
	{
		Task<DriverDto> Get(Guid userId);
	}
}
