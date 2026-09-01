using Hospital_ERP_Backend.API.Extensions;
using Hospital_ERP_Backend.API.Extensions.Configuration;
using Hospital_ERP_Backend.API.Middleware;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSettingConfiguration(builder.Configuration);
builder.Services.AddMediatorConfigurationExtension();

builder.Services.AddCorsConfigurationExtension(builder.Configuration);
builder.Services.AddJwtAuthenticationExtension(builder.Configuration);

builder.Services.AddAuthorizationConfigurationExtension();
builder.Services.AddControllers();
builder.Services.AddApiBehaviorConfigurationExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenExtension();

builder.Services.AddAPIServiceExtension(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
