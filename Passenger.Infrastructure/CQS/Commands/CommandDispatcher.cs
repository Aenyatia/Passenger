using Autofac;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.CQS.Commands
{
	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly IComponentContext _componentContext;

		public CommandDispatcher(IComponentContext componentContext)
		{
			_componentContext = componentContext;
		}

		public async Task Dispatch<T>(T command) where T : ICommand
		{
			var handler = _componentContext.Resolve<ICommandHandler<T>>();
			await handler.Handle(command);
		}
	}
}
