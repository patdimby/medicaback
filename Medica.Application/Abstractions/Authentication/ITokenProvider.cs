using Medica.Core.Domains;

namespace Medica.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    string Create(User user);
}
