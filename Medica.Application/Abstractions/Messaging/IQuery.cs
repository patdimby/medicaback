using MediatR;
using Medica.SharedKernel.Models;

namespace Medica.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
