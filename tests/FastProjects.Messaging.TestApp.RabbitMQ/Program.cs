using FastEndpoints;
using FastEndpoints.Swagger;
using FastProjects.Messaging;
using FastProjects.Messaging.TestApp.RabbitMQ;
using FastProjects.Messaging.TestApp.RabbitMQ.Messaging;
using MassTransit;
using Microsoft.Extensions.Options;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// FastEndpoints
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.DocumentName = "Initial Release";
        s.Title = "FastProjects.Endpoints Test API";
        s.Description = "API to test the FastProjects.Endpoints library";
        s.Version = "v0";
    };
});

// MassTransit
builder.Services.Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    
    // Consumers here
    x.AddConsumer<ProjectCreatedIntegrationEventConsumer>()
        .Endpoint(e => e.Name = "project-created");
    
    x.UsingRabbitMq((context, cfg) =>
    {
        RabbitMQOptions options = context.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
        cfg.Host(options.ConnectionString);
        cfg.ConfigureEndpoints(context);
    });
});

// Messaging
builder.Services.AddTransient<IIntegrationEventPublisher, MassTransitMessagePublisher>();

WebApplication app = builder.Build();

app.MapFastEndpoints();
app.UseSwaggerGen();

app.Run();

public partial class Program;
