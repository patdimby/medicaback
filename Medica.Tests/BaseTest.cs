using System.Reflection;
using System.Windows.Input;
using Medica.Core.Domains;
using Medica.Infrastructure.Database;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Medica.Tests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(ICommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
