using System;
using Domain._Base;

namespace Domain.Events
{
    public class Event: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public Event(string _name, string _description, DateTime _startDate, DateTime _finishDate, int _id=0)
        {
            this.Name = _name;
            this.Id = _id;
            this.Description = _description;
            this.StartDate = _startDate;
            this.FinishDate = _finishDate;
        }
    }
}
