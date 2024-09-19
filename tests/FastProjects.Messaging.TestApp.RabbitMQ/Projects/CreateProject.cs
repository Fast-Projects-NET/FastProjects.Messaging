using FastProjects.Endpoints;
using FastProjects.Messaging.TestApp.RabbitMQ.Messaging;
using FastProjects.ResultPattern;
using MediatR;

namespace FastProjects.Messaging.TestApp.RabbitMQ.Projects;

// Presentation layer
public sealed class CreateProjectEndpoint(IMediator mediator)
    : FastEndpoint<CreateProjectCommand,
        ProjectModel,
        CreateProjectCommand,
        Result<ProjectModel>,
        ProjectModel>(mediator)
{
    public override void Configure()
    {
        Post("/projects");
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreateProjectCommand("Project");
            s.ResponseExamples[200] = new ProjectModel(1, "Project");
        });
    }

    protected override CreateProjectCommand CreateMediatorCommand(CreateProjectCommand request) => request;

    protected override ProjectModel CreateResponse(ProjectModel data) => data;
}

// Application layer
public sealed record CreateProjectCommand(string Name) : SharedKernel.ICommand<ProjectModel>;

public sealed class CreateProjectCommandHandler(
    IIntegrationEventPublisher integrationEventPublisher)
    : SharedKernel.ICommandHandler<CreateProjectCommand, ProjectModel>
{

    public async Task<Result<ProjectModel>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new ProjectModel(1, request.Name);
        
        var integrationEvent = new ProjectCreatedIntegrationEvent
        {
            EventId = Guid.NewGuid(),
            OccurredOn = DateTime.UtcNow,
            ProjectId = project.Id,
            ProjectName = project.Name
        };

        await integrationEventPublisher.PublishAsync(integrationEvent, cancellationToken);

        return Result.Success(project);
    }
}
