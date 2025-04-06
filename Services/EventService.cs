using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntraNet.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IntraNetDbContext _context;
        public EventService(IntraNetDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateEvent(CreateEventDto dto)
        {
            var newEvent = _mapper.Map<Event>(dto);
            if(newEvent is null)
            {
                throw new NotFoundException("dto not found");
            }
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent.Id;
        }

        public async Task DeleteEvent(int id)
        {
            var removeEvent = await _context.Events.FirstOrDefaultAsync(e=> e.Id == id);
            if (removeEvent is null)
                throw new NotFoundException("Event not found");
            _context.Events.Remove(removeEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<EventDto>> GetAll(EventQuery query)
        {
            var events = await _context.Events.Where(e => query.Name == null || (e.Name.ToLower().Contains(query.Name.ToLower()))).ToListAsync();

            var total = events.Count;
            var paginatedEvents = events.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);

            var eventsDto = _mapper.Map<List<EventDto>>(paginatedEvents);
            var result = new PagedResult<EventDto>(eventsDto, total, query.PageSize, query.PageNumber);
            return result;
        }

        public async Task<EventDto> GetById(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(e=>e.Id == id);
            if (result == null)
                throw new NotFoundException("Event not found");
            return _mapper.Map<EventDto>(result);
        }
    }
}
