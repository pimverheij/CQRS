using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CommandHandlers
{
    public interface ICommandHandler<ICommand>
    {
        Task HandleAsync(ICommand command);
    }
}
