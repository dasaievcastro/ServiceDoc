using System;
namespace Domain.Events
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
    }
}
