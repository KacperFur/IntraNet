using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEventService
    {
        Task<int> CreateEvent(CreateEventDto dto, CancellationToken cancellationToken);
        Task<PagedResult<EventDto>> GetAll(EventQuery query, CancellationToken cancellationToken);
        Task<EventDto> GetById(int id, CancellationToken cancellationToken);
        Task DeleteEvent(int id, CancellationToken cancellationToken);
    }
}
