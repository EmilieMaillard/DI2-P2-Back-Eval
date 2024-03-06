using System.Net;
using DI2_P2_Back_Eval.Entity;
using DI2_P2_Back_Eval.Service;
using DI2_P2_Back_Eval.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace DI2_P2_Back_Eval.API.AzureFunctions;

public class EventPostFunction
{
    /// <summary>
    /// The event service.
    /// </summary>
    private readonly IEventService _eventService;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventPostFunction"/> class.
    /// </summary>
    public EventPostFunction(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="EventPostFunction"/> class.
    /// </summary>
    /// <param name="req">The HTTP request data.</param>
    /// <returns>The HTTP response data.</returns>
    [Function("EventPost")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "events")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.Created);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var newEvent = JsonConvert.DeserializeObject<Event>(requestBody);
            
            if (newEvent != null)
            {
                if (!_eventService.AddAsync(newEvent))
                {
                    await response.WriteStringAsync("This event already exists.");
                    response.StatusCode = HttpStatusCode.Conflict;
                }
            }
        }
        catch (Exception ex)
        {
            await response.WriteStringAsync(ex.Message);
            response.StatusCode = HttpStatusCode.InternalServerError;
        }
        
        return response;
    }
    
    
    
    
    
}