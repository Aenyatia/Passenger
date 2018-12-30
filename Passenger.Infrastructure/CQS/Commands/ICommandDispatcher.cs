using System.Threading.Tasks;

namespace Passenger.Infrastructure.CQS.Commands
{
	public interface ICommandDispatcher
	{
		Task Dispatch<T>(T command) where T : ICommand;
	}
}
