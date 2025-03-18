using AutoMapper;
using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet
{
    public class IntranetMappingProfile : Profile
    {
        public IntranetMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(d=>d.TasksAssigned, o => o.MapFrom(s=>s.TasksAssigned));

            CreateMap<UpdateEmployeeTaskDto, EmployeeTask>()
                .ForMember(d => d.AssignedEmployeeId, e => e.MapFrom(f => f.AssignedEmployeeId));

            CreateMap<EmployeeTask, EmployeeTaskDto>();

            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<CreateEmployeeTaskDto, EmployeeTask>();

            CreateMap<Event, EventDto>();
            CreateMap<CreateEventDto, Event>();
        }
    }
}
