using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEventService
    {
        Task<int> CreateEvent(CreateEventDto dto);
        Task<List<EventDto>> GetAll();
        Task<EventDto> GetById(int id);
        Task DeleteEvent(int id);
    }
}
