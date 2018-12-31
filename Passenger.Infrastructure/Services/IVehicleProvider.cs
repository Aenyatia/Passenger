using Passenger.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
	public interface IVehicleProvider : IService
	{
		Task<IEnumerable<VehicleDto>> GetAll();
		Task<VehicleDto> Get(string brand, string model);
	}
}
