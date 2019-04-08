using System;
using Domain._Base;

namespace Domain.Events
{
    public class EventStorage
    {
        private readonly IEventRepository _eventRepository;

        public EventStorage(IEventRepository e)
        {
            _eventRepository = e;
        }

        public void Add(EventDto _eventDto)
        {

            var EventObject = EventBuilder.Create()
                .HasName(_eventDto.Name)
                .HasDescription(_eventDto.Description)
                .HasStartDate(_eventDto.StartDate)
                .HasFinishDate(_eventDto.FinishDate)
                .Builder();



            //if (cursoDto.Id == 0)
                _eventRepository.Add(EventObject);
        }
    }
}
