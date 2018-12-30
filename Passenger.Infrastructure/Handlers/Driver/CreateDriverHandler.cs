using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Driver
{
	public class CreateDriverHandler : ICommandHandler<CreateDriver>
	{
		private readonly IDriverService _driverService;

		public CreateDriverHandler(IDriverService driverService)
		{
			_driverService = driverService;
		}

		public async Task Handle(CreateDriver command)
		{
			await _driverService.Create(command.UserId, command.Vehicle);
		}
	}
}
