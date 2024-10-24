using rabbit_mq_pub_sub.Controllers;
using rabbit_mq_pub_sub.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRabbitMQService();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assessment", Version = "v1" });
});

var app = builder.Build();

app.AddApiEndpoints();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assessment"));


app.UseHttpsRedirection();



app.Run();
