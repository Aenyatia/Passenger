using System.Threading.Tasks;

namespace Passenger.Infrastructure.CQS.Commands
{
	public interface ICommandHandler<in T> where T : ICommand
	{
		Task Handle(T command);
	}
}
