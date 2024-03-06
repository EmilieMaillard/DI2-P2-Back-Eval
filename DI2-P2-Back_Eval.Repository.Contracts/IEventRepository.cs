using DI2_P2_Back_Eval.Entity;

namespace DI2_P2_Back_Eval.Repository.Contracts;

public interface IEventRepository
{
    /// <summary>
    /// Add an event to the database.
    /// </summary>
    /// <param name="entity"> The event to add. </param>
    void AddAsync(Event entity);
    
    /// <summary>
    /// Get all events from the database.
    /// </summary>
    /// <returns></returns>
    List<Event> GetAll();
    
    /// <summary>
    /// Update an event in the database.
    /// </summary>
    /// <param name="entity"> The event to update. </param>
    void UpdateAsync(Event entity);
    
    
}