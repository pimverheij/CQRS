using CQRS.Commands;
using System;
using System.Threading.Tasks;

namespace CQRS.CommandHandlers
{
    public interface ICommandExecutor
    {
        Task Execute(ICommand command);
    }

    public class CommandExecutor : ICommandExecutor
    {
        private IServiceProvider _serviceProvider;

        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _serviceProvider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }
    }
}
