using System;
namespace Domain.Event
{
    public class EventBuilder
    {

        public string _name { get; set; }
        public string _description { get; set; }
        public string _startDate { get; set; }
        public string _finishDate { get; set; }

        public static EventBuilder Create()
        {
            return new EventBuilder();
        }

        public EventBuilder HasName(string _name)
        {
            this._name = _name;
            return this;
        }

        public EventBuilder HasDescription(string _description)
        {
            this._description = _description;
            return this;
        }

        public EventBuilder HasStartDate(string _startDate)
        {
            this._startDate = _startDate;
            return this;
        }

        public EventBuilder HasFinishDate(string _finishDate)
        {
            this._finishDate = _finishDate;
            return this;
        }

        public Event Builder()
        {
            return new Event(_name, _description, _startDate, _finishDate);
        }
    }
}
