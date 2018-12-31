using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Driver
{
	public class UpdateDriverHandler : ICommandHandler<UpdateDriver>
	{
		private readonly IDriverService _driverService;

		public UpdateDriverHandler(IDriverService driverService)
		{
			_driverService = driverService;
		}

		public async Task Handle(UpdateDriver command)
		{
			var vehicle = command.Vehicle;
			await _driverService.SetVehicle(command.UserId, vehicle.Brand, vehicle.Model);
		}
	}
}
