using System;
using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Events
{
    /// <summary>
    /// Base class for events. Provides a timestamp so consumers can know when
    /// the event occurred.
    /// </summary>
    public abstract class EventBase : IEvent
    {
        public DateTime Timestamp { get; }

        protected EventBase()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
