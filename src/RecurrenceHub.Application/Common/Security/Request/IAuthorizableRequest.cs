using MediatR;

namespace RecurrenceHub.Application.Common.Security.Request;

public interface IAuthorizableRequest<out T> : IRequest<T>
{
    Guid UserId { get; }
}