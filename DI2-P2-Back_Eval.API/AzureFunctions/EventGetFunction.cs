using DI2_P2_Back_Eval.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace DI2_P2_Back_Eval.API.AzureFunctions;

public class EventGetFunction
{
    /// <summary>
    /// The event service.
    /// </summary>
    private readonly IEventService _eventService;
    
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="eventService"> The event service. </param>
    public EventGetFunction(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    /// <summary>
    /// Get all events.
    /// </summary>
    /// <param name="req"> The HTTP request data. </param>
    /// <returns> The HTTP response data. </returns>
    [Function("EventGetFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "events")] HttpRequestData req)
    {
        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        try
        {
            var events = _eventService.GetAll();
            var eventsJson = System.Text.Json.JsonSerializer.Serialize(events);
            await response.WriteStringAsync(eventsJson);
        }
        catch (Exception ex)
        {
            await response.WriteStringAsync(ex.Message);
            response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        }
        
        return response;
    }
}