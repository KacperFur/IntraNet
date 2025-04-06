using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEventService
    {
        Task<int> CreateEvent(CreateEventDto dto);
        Task<PagedResult<EventDto>> GetAll(EventQuery query);
        Task<EventDto> GetById(int id);
        Task DeleteEvent(int id);
    }
}
