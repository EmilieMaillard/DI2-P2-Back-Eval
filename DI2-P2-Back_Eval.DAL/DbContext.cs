using Microsoft.EntityFrameworkCore;

namespace DI2_P2_Back_Eval.DAL;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
    
    
}