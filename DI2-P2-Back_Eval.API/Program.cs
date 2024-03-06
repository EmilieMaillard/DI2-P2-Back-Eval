using DI2_P2_Back_Eval.Repository;
using DI2_P2_Back_Eval.Repository.Contracts;
using DI2_P2_Back_Eval.Service;
using DI2_P2_Back_Eval.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DbContext = DI2_P2_Back_Eval.DAL.DbContext;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<DbContext>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IEventRepository, EventRepository>();
    })
.Build();

host.Run();