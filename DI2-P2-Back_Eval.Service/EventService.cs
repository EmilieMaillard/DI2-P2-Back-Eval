using DI2_P2_Back_Eval.Entity;
using DI2_P2_Back_Eval.Repository.Contracts;
using DI2_P2_Back_Eval.Service.Contracts;

namespace DI2_P2_Back_Eval.Service;

public class EventService : IEventService
{
    /// <summary>
    /// The event repository.
    /// </summary>
    private readonly IEventRepository _eventRepository;
    
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="eventRepository"> The event repository. </param>
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    /// <summary>
    /// Add an event to the database.
    /// </summary>
    /// <param name="entity"> The event to add. </param>
    /// <returns> True if the event was added. </returns>
    public bool AddAsync(Event entity)
    {
        _eventRepository.AddAsync(entity);
        return true;
    }
    
    /// <summary>
    /// Get all events from the database.
    /// </summary>
    /// <returns> A list of all events. </returns>
    public List<Event> GetAll()
    {
        return _eventRepository.GetAll();
    }
}