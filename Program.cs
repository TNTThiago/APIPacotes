using API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabase();
builder.Services.DependecyInjection();
builder.Services.ConfigureCORS();

builder.Services.RegisterAuthentication();
builder.Services.RegisterAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!").RequireAuthorization("User");

app.Run();

app.Run("http://localhost:3002");
