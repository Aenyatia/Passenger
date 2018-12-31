using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Driver
{
	public class DeleteDriverRouteHandler : ICommandHandler<DeleteDriverRoute>
	{
		private readonly IDriverRouteService _driverRouteService;

		public DeleteDriverRouteHandler(IDriverRouteService driverRouteService)
		{
			_driverRouteService = driverRouteService;
		}


		public async Task Handle(DeleteDriverRoute command)
		{
			await _driverRouteService.Delete(command.UserId, command.Name);
		}
	}
}
