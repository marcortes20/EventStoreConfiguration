using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.EventStore;

namespace EventStoreConf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStoreController : ControllerBase
    {
        private readonly IEventStoreService _eventStoreService;

        public EventStoreController(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Purchase purchase)
        {
            var eventData = _eventStoreService.CreateEvent(purchase);
             await _eventStoreService.AppendEventToStream( eventData );
            return  Ok("EVENT CREATED SUCCESFULLY");
        }
    }
}
