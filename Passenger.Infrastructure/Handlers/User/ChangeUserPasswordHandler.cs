using Passenger.Infrastructure.Commands.User;
using Passenger.Infrastructure.CQS.Commands;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.User
{
	public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
	{
		public async Task Handle(ChangeUserPassword command)
		{
			await Task.CompletedTask;
		}
	}
}
