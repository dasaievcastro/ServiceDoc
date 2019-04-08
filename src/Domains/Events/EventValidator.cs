using System;
using FluentValidation;

namespace Domain.Events
{


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
                .Must(validDate)
                .WithMessage("Please enter a valid Start Date");

            RuleFor(e => e.FinishDate).Cascade(CascadeMode.Continue)
                .NotNull()
                .Must(validDate)
                .GreaterThan(e => e.StartDate)
                .WithMessage("Please enter a valid Finish Date");

        }

        public bool validDate(DateTime date)
        {
            return ( date != new DateTime());
        }
    }

}
