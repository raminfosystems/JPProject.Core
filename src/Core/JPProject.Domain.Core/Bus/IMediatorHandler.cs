using System.Threading.Tasks;
using JPProject.Domain.Core.Commands;
using JPProject.Domain.Core.Events;

namespace JPProject.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
