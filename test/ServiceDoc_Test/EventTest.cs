using System;
using ExpectedObjects;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace ServiceDoc_Test
{
    public class EventTest
    {
        public string _Name { get; set; }
        public string _Description { get; set; }
        public string _StartDate { get; set; }
        public string _FinishDate { get; set; }
        public EventValidator validator { get; set; }

        public EventTest()
        {

            _Name = "Event name Test";
            _Description = "Event description";
            _StartDate = "2019/03/07";
            _FinishDate = "2019/03/07";
            validator = new EventValidator();
        }
        [Fact]
        public void Should_have_create_an_event()
        {

            var EventTest = new
            {
                Name = _Name,
                Description = _Description,
                StartDate = _StartDate,
                FinishDate = _FinishDate

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

        [Fact]
        public void Should_have_error_when_Name_is_null_or_its_length_is_less_than_3()
        {
            var InvalidName = string.Empty;
            Event EventBuilderObject = EventBuilder
                            .Create()
                            .HasName(InvalidName)
                            .Builder();
            validator.ShouldHaveValidationErrorFor(e => e.Name, EventBuilderObject);

        }

        [Fact]
        public void Should_have_error_when_Description_is_null_or_its_length_is_less_than_3()
        {
            var InvalidDescription = string.Empty;
            Event EventBuilderObject = EventBuilder
                            .Create()
                            .HasDescription(InvalidDescription)
                            .Builder();
            validator.ShouldHaveValidationErrorFor(e => e.Description, EventBuilderObject);

        }

        [Fact]
        public void Should_have_error_when_StartDate_is_null_or_invalid()
        {
            var InvalidDate = "2019/02/31";
            Event EventBuilderObject = EventBuilder
                            .Create()
                            .HasStartDate(InvalidDate)
                            .Builder();
            validator.ShouldHaveValidationErrorFor(e => e.StartDate, EventBuilderObject);

        }


        [Fact]
        public void Should_have_error_when_FinishDate_is_null_or_invalid()
        {
            var InvalidDate = "2019/02/31";
            Event EventBuilderObject = EventBuilder
                            .Create()
                            .HasFinishDate(InvalidDate)
                            .Builder();
            validator.ShouldHaveValidationErrorFor(e => e.FinishDate, EventBuilderObject);

        }

        [Fact]
        public void Should_have_error_when_FinishDate_is_less_than_startDate()
        {
            var finishDate = "2019/02/19";
            var startDate = "2019/02/20";
            Event EventBuilderObject = EventBuilder
                            .Create()
                            .HasFinishDate(finishDate)
                            .HasStartDate(startDate)
                            .Builder();
            validator.ShouldHaveValidationErrorFor(e => e.FinishDate, EventBuilderObject);

        }
    }


}

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

public class EventValidator : AbstractValidator<Event>
{

    public EventValidator()
    {
        RuleFor(e => e.Name).Cascade(CascadeMode.Continue)
            .NotNull().NotEmpty().Length(3, 100)
            .WithMessage("Please enter a valid name");

        RuleFor(e => e.Description).Cascade(CascadeMode.Continue)
            .NotNull().NotEmpty().Length(3, 300)
            .WithMessage("Please enter a valid Description");

        RuleFor(e => e.StartDate).Cascade(CascadeMode.Continue)
            .NotNull()
            .Must(validateDate)
            .WithMessage("Please enter a valid Start Date");

        RuleFor(e => e.FinishDate).Cascade(CascadeMode.Continue)
            .NotNull()
            .Must(validateDate)
            .GreaterThan(e => e.StartDate)
            .WithMessage("Please enter a valid Finish Date");

    }

    public bool validateDate(string date)
    {
        DateTime vDate;
        return DateTime.TryParse(date, out vDate);
    }

}
