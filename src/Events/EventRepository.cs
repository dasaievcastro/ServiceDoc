using System;
using Domain._Base;
using Domain.Context;

namespace Domain.Events
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
