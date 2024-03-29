﻿using DI2_P2_Back_Eval.DAL;
using DI2_P2_Back_Eval.Entity;
using DI2_P2_Back_Eval.Repository.Contracts;

namespace DI2_P2_Back_Eval.Repository;

public class EventRepository : IEventRepository
{
    /// <summary>
    /// The database context.
    /// </summary>
    private readonly DbContext _dbContext;
    
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="dbContext"> The database context. </param>
    public EventRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Add an event to the database.
    /// </summary>
    /// <param name="entity"> The event to add. </param>
    public void AddAsync(Event entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }
    
    /// <summary>
    /// Get all events from the database.
    /// </summary>
    /// <returns> A list of all events. </returns>
    public List<Event> GetAll()
    {
        return _dbContext.Set<Event>().ToList();
    }
    
    /// <summary>
    /// Update an event in the database.
    /// </summary>
    /// <param name="entity"> The event to update. </param>
    public void UpdateAsync(Event entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
    
    
    
}