using System;
using Domain._Base;
using FluentValidation;

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

                EventValidator validateEvent = new EventValidator();

                validateEvent.ValidateAndThrow(EventObject);

                //edit
            if (_eventDto.Id > 0)
                {
                    var EventObjectEdit = _eventRepository.SearchForId(_eventDto.Id);
                    EventObjectEdit.Name = _eventDto.Name;
                    EventObjectEdit.Description = _eventDto.Description;
                    EventObjectEdit.StartDate = EventObject.StartDate;
                    EventObjectEdit.FinishDate = EventObject.FinishDate;
                }
                //add
                if (_eventDto.Id == 0)
                    _eventRepository.Add(EventObject);
           

        }

        public void Remove(int id)
        {
            var EventObjectRemove = _eventRepository.SearchForId(id);

            _eventRepository.Remove(EventObjectRemove);
        }
    }
}
