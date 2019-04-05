using System;
using ExpectedObjects;
using Xunit;

namespace ServiceDoc_Test
{
    public class EventTest
    {
        [Fact]
        public void Should_have_create_an_event()
        {

            var EventTest = new
            {
                Name = "Event name Test",
                Description = "Event description",
                StartDate = new DateTime(),
                FinishDate = new DateTime()

            };
            
            Event EventBuilderObject = EventBuilder
                .Create()
                .HasName(EventTest.Name)
                .HasDescription(EventTest.Description)
                .HasStartDate(EventTest.StartDate)
                .HasFinishDate(EventTest.FinishDate)
                .Builder();

            EventTest.ToExpectedObject().ShouldMatch(EventBuilderObject);
        }
    }


}

public class Event
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }

    public Event(string _name, string _description, DateTime _startDate, DateTime _finishDate)
    {
        this.Name = _name;
        this.Description = _description;
        this.StartDate = _startDate;
        this.FinishDate = _finishDate;

    }
}

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

    public EventBuilder HasStartDate(DateTime _startDate)
    {
        this._startDate = _startDate;
        return this;
    }

    public EventBuilder HasFinishDate(DateTime _finishDate)
    {
        this._finishDate = _finishDate;
        return this;
    }

    public Event Builder()
    {
        return new Event(_name, _description, _startDate, _finishDate);
    }
}
