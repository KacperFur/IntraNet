using IntraNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntraNet.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.Role)
                .WithMany().HasForeignKey(z => z.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
