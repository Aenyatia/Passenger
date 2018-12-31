using Passenger.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IDriverService : IService
	{
		Task<DriverDto> Get(Guid userId);
		Task<IEnumerable<DriverDto>> GetAll();

		Task Create(Guid userId);
		Task SetVehicle(Guid userId, string brand, string model, int seats);
	}
}
