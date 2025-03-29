using IntraNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntraNet
{
    public class EventSeeder : Seeder<Event>
    {
        public EventSeeder(IntraNetDbContext context) : base(context) { }
        public override IEnumerable<Event> GetItems()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Name = "Christmas Eve",
                    Description = "day off",
                    Date = new DateTime(2025,12,29),
                    AuthorId = 15
                },
                new Event()
                {
                    Name = "Independence day",
                    Description = "day off",
                    Date = new DateTime(2025,11,11),
                    AuthorId = 15
                }

            };

            return events;
        }
    }
}
