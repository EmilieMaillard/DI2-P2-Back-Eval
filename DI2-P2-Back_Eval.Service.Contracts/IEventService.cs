using DI2_P2_Back_Eval.Entity;

namespace DI2_P2_Back_Eval.Service.Contracts;

public interface IEventService
{
    /// <summary>
    /// Add an event to the database.
    /// </summary>
    /// <param name="entity"> The event to add. </param>
    /// <returns>True if the event was added. </returns>
    bool AddAsync(Event entity);
}