using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Extensions;
using IntraNet.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntraNet.Services
{
    public class EventService : IEventService
    { 
        private readonly IntraNetDbContext _context;
        public EventService(IntraNetDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEvent(CreateEventDto dto, CancellationToken cancellationToken)
        {
            var newEvent = dto.Adapt<Event>();
            if (newEvent is null)
            {
                throw new NotFoundException("dto not found");
            }
            await _context.Events.AddAsync(newEvent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEvent.Id;
        }

        public async Task DeleteEvent(int id, CancellationToken cancellationToken)
        {
            var removeEvent = await _context.Events.FirstOrDefaultAsync(e=> e.Id == id, cancellationToken);
            if (removeEvent is null)
                throw new NotFoundException("Event not found");
            _context.Events.Remove(removeEvent);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PagedResult<EventDto>> GetAll(EventQuery query, CancellationToken cancellationToken)
        {
            var events = _context.Events
                .AsNoTracking().Where(e => query.Name == null || (e.Name.ToLower().Contains(query.Name.ToLower())));

            var paginatedEvents = await events.Paginate(query.PageNumber, query.PageSize).ToListAsync(); 
            var total = await events.CountAsync();
            

            var eventsDto = paginatedEvents.Adapt<List<EventDto>>();
            var result = new PagedResult<EventDto>(eventsDto, total, query.PageSize, query.PageNumber);
            return result;
        }

        public async Task<EventDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _context.Events.AsNoTracking().FirstOrDefaultAsync(e=>e.Id == id, cancellationToken);
            if (result is null)
                throw new NotFoundException("Event not found");
            return result.Adapt<EventDto>();
        }
    }
}
