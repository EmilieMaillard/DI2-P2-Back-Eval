using DI2_P2_Back_Eval.Entity;
using DI2_P2_Back_Eval.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace DI2_P2_Back_Eval.API.AzureFunctions;

public class EventUpdateFunction
{
    /// <summary>
    /// The event service.
    /// </summary>
    private readonly IEventService _eventService;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventUpdateFunction"/> class.
    /// </summary>
    /// <param name="eventService"></param>
    public EventUpdateFunction(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Update an event.
    /// </summary>
    /// <param name="req"> The HTTP request data. </param>
    /// <param name="id"> The event id. </param>
    /// <returns> The HTTP response data. </returns>
    [Function("EventUpdateFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "events/{id}")] HttpRequestData req, string id)
    {
        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateEvent = JsonConvert.DeserializeObject<Event>(requestBody);
            
            if (updateEvent != null)
            {
                if (!_eventService.UpdateAsync(updateEvent))
                {
                    await response.WriteStringAsync("This event does not exist.");
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
        }
        catch (Exception ex)
        {
            await response.WriteStringAsync(ex.Message);
            response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        }
        
        return response;
        
    }
}