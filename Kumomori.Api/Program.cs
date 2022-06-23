using Kumomori.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    builder.Services.AddDbContext<StoreContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetValue<string>("Database:ConnectionString"));
    });
}

var app = builder.Build();
{
    app.MapGet("/", () => "Hello World!");

    app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        context.Database.Migrate();
        DbInitializer.Initialize(context);
    }

    app.Run();
}
