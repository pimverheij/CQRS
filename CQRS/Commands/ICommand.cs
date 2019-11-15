using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}
