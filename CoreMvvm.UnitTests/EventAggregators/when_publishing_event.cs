using NUnit.Framework;
using Shouldly;

namespace CoreMvvm.UnitTests.EventAggregators
{
    [TestFixture]
    public class when_publishing_event
    {
        private readonly object _data = new object();
        private object _handledData;

        [SetUp]
        public async void Context()
        {
            var eventAggregator = new EventAggregator();
            eventAggregator.Subscribe<TestEvent>(async x => _handledData = x.Data);

            await eventAggregator.Publish(new TestEvent { Data = _data });
        }

        [Test]
        public void event_is_handled()
        {
            _handledData.ShouldBe(_data);
        }

        private class TestEvent
        {
            public object Data { get; set; }
        }
    }
}