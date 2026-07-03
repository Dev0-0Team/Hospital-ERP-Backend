using Hopital_ERP_Backend.API.Extensions.Configuration;
using Hopital_ERP_Backend.API.Filters;
using Hospital_ERP_Backend.API.Extensions;
using Hospital_ERP_Backend.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSettingConfiguration(builder.Configuration);
builder.Services.AddMediatorConfigurationExtension();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<DefaultResponsesOperationFilter>();
});

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
