using Entities;
using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static EventStore.Client.StreamMessage;

namespace Services.EventStore
{
    public class EventStoreService : IEventStoreService
    {

        private readonly EventStoreClient _eventStoreClient;

        public EventStoreService(EventStoreClient eventStoreClient)
        {
            _eventStoreClient = eventStoreClient;
        }

        public EventData CreateEvent(Purchase purchase)
        {
            return new EventData(
            Uuid.NewUuid(),
           "PurchaseEvent",
           JsonSerializer.SerializeToUtf8Bytes(purchase)
           );
        }

       async public Task AppendEventToStream( params EventData[] eventData)
        {
            await _eventStoreClient.AppendToStreamAsync(
           "PurchaseStream",
           StreamState.Any,
           eventData
           );
        }

       
    }
}
