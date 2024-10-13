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
         EventData CreateEvent(Purchase purchase);

         Task AppendEventToStream(params EventData[] eventData);

        Task TestStream();


    }
}
