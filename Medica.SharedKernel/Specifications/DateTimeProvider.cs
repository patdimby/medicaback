using Medica.SharedKernel.Interfaces;

namespace Medica.SharedKernel.Specifications;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
