using Entities;
using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EventStore
{
    public interface IEventStoreService
    {
        public EventData CreateEvent(Purchase purchase);

        public Task AppendEventToStream(params EventData[] eventData);
    }
}
