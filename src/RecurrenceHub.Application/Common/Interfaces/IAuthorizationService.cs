using ErrorOr;

using RecurrenceHub.Application.Common.Security.Request;

namespace RecurrenceHub.Application.Common.Interfaces;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizableRequest<T> request,
        ICollection<string> requiredRoles,
        ICollection<string> requiredPermisssions,
        ICollection<string> requiredPolicies);
}