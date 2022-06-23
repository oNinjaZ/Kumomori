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

    builder.Services.AddCors();
}

var app = builder.Build();
{
    app.MapGet("/", () => "Hello World!");

    app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(opts =>
    {
        opts.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
    });

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        context.Database.Migrate();
        DbInitializer.Initialize(context);
    }

    app.Run();
}
