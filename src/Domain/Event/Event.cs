using System;
namespace Domain.Event
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }

        public Event(string _name, string _description, string _startDate, string _finishDate)
        {
            this.Name = _name;
            this.Description = _description;
            this.StartDate = _startDate;
            this.FinishDate = _finishDate;

        }
    }
}
