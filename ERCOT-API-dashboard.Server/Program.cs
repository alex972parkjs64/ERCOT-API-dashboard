using ERCOT_API_dashboard.Server.Services;
using ERCOT_API_dashboard.Server.Services.Interface;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddTransient<IErcotTokenService, ErcotTokenService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERCOT API Dashboard", Version = "v1" });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseSwagger();
app.MapStaticAssets();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.MapOpenApi();    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();
