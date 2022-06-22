var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
}

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
