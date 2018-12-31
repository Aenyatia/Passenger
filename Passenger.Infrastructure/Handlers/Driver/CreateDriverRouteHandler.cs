using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.CQS.Commands;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Driver
{
	public class CreateDriverRouteHandler : ICommandHandler<CreateDriverRoute>
	{
		private readonly IDriverRouteService _driverRouteService;

		public CreateDriverRouteHandler(IDriverRouteService driverRouteService)
		{
			_driverRouteService = driverRouteService;
		}

		public async Task Handle(CreateDriverRoute command)
		{
			await _driverRouteService.Add(command.UserId, command.Name,
				command.StartLatitude, command.StartLongitude,
				command.EndLatitude, command.EndLongitude);
		}
	}
}
