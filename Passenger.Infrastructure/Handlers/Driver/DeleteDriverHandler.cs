using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Driver
{
	public class DeleteDriverHandler : ICommandHandler<DeleteDriver>
	{
		private readonly IDriverService _driverService;

		public DeleteDriverHandler(IDriverService driverService)
		{
			_driverService = driverService;
		}

		public async Task Handle(DeleteDriver command)
		{
			await _driverService.Remove(command.UserId);
		}
	}
}
