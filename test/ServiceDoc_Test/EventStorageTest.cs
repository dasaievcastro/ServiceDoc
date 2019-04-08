using Bogus;
using Domain.Events;
using Moq;
using Xunit;

namespace ServiceDoc_Test
{
    public class EventStorageTest
    {
        public EventDto _eventDto;
        private readonly EventStorage _eventStorage;
        private readonly Mock<IEventRepository> _eventRepositoryMock;
        public EventStorageTest()
        {
            var fake = new Faker();
            _eventDto = new EventDto
            {
                Name = fake.Random.Words(),
                Description = fake.Lorem.Paragraph(),
                StartDate = fake.Date.Recent().ToString(),
                FinishDate = fake.Date.Recent().ToString()
            };

            _eventRepositoryMock = new Mock<IEventRepository>();
            _eventStorage = new EventStorage(_eventRepositoryMock.Object);
        }

        [Fact]
        public void Should_add_an_Event()
        {
            _eventStorage.Add(_eventDto);

            _eventRepositoryMock.Verify(r => r.Add(
                It.Is<Event>(
                    c => c.Name == _eventDto.Name &&
                    c.Description == _eventDto.Description
                )
            ));
        }

        //others tests 
    }
}

