using IntraNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntraNet.EntityConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(e => e.EventAuthor)
                .WithMany(w => w.Events).HasForeignKey(z => z.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
