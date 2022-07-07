using Kumomori.Api.Data;
using Kumomori.Api.Middleware;
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
    app.UseMiddleware<ExceptionMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseCors(opts =>
    {
        opts.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000");
    });

    app.MapControllers();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        context.Database.Migrate();
        DbInitializer.Initialize(context);
    }

    app.Run();
}
