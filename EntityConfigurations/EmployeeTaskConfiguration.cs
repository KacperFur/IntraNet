using IntraNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntraNet.EntityConfigurations
{
    public class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        void IEntityTypeConfiguration<EmployeeTask>.Configure(EntityTypeBuilder<EmployeeTask> builder)
        {
            builder.HasOne(e => e.AssignedEmployee)
                .WithMany(w => w.TasksAssigned).HasForeignKey(z => z.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
