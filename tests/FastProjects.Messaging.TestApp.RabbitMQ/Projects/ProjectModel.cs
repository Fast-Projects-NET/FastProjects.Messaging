using FastProjects.SharedKernel;

namespace FastProjects.Messaging.TestApp.RabbitMQ.Projects;

public sealed class ProjectModel : EntityBase<int>, IAggregateRoot
{
    public ProjectModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    private ProjectModel()
    {
    }
    
    public string Name { get; set; }
}
