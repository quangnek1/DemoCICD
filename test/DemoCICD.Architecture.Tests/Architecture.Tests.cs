namespace DemoCICD.Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "DemoCICD.Domain";
    private const string ApplicationNamespace = "DemoCICD.Applicaion";
    private const string InfrastructureNamespace = "DemoCICD.Infrastructure";
    private const string PersistenceNamespace = "DemoCICD.Persistence";
    private const string PresentationNamespace = "DemoCICD.Presentation";
    private const string WebApiNamespace = "DemoCICD.WebApi";


    [Fact]
    public void Domain_Should_Not_HaveDependenceOnOtherProject()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            WebApiNamespace
        };

        // Act

        // Assert
    }
}
