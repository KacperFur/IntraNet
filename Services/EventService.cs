using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<EventDto>> GetAll()
        {
            var events = await _context.Events.ToListAsync();
            var eventsDto = _mapper.Map<List<EventDto>>(events);
            return eventsDto;
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
