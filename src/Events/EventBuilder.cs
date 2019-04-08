using System;
namespace Domain.Events
{
    public class EventBuilder
    {

        public string _name { get; set; }
        public string _description { get; set; }
        public DateTime _startDate { get; set; }
        public DateTime _finishDate { get; set; }

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
            DateTime validDate;
            DateTime.TryParse(_startDate, out validDate);
            this._startDate = validDate;
            return this;
        }

        public EventBuilder HasFinishDate(string _finishDate)
        {
            DateTime validDate = new DateTime();
            DateTime.TryParse(_finishDate, out validDate);
            this._finishDate = validDate;
            return this;
        }

        public Event Builder()
        {
            return new Event(_name, _description, _startDate, _finishDate);
        }
    }
}
