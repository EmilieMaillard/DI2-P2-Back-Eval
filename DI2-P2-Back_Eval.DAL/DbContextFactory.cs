using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DI2_P2_Back_Eval.DAL;

public class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
{
    public DbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseSqlServer("Server=EMILIEMAILLARD;Database=DbDi2P2Evaluation;Trusted_Connection=True;TrustServerCertificate=True");

        return new DbContext(optionsBuilder.Options);
    }
}