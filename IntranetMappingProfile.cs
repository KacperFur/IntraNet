using IntraNet.Entities;
using IntraNet.Models;
using Mapster;

namespace IntraNet
{

    public static class MapsterConfiguration
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Employee, EmployeeDto>
                .NewConfig()
                .Map(dest => dest.TasksAssigned, src => src.TasksAssigned);

            TypeAdapterConfig<UpdateEmployeeTaskDto, EmployeeTask>
                .NewConfig()
                .Map(dest => dest.AssignedEmployeeId, src => src.AssignedEmployeeId);

            TypeAdapterConfig<EmployeeTask, EmployeeTaskDto>.NewConfig();

            TypeAdapterConfig<CreateEmployeeDto, Employee>.NewConfig();

            TypeAdapterConfig<CreateEmployeeTaskDto, EmployeeTask>.NewConfig();

            TypeAdapterConfig<Event, EventDto>.NewConfig();

            TypeAdapterConfig<CreateEventDto, Event>.NewConfig();
        }
    }
}
