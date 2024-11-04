using System.Reflection;

using ErrorOr;

using MediatR;

using RecurrenceHub.Application.Common.Interfaces;
using RecurrenceHub.Application.Common.Security.Request;

using Throw;

namespace RecurrenceHub.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse>(
    IAuthorizationService authorizationService)
        : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IAuthorizableRequest<TResponse>
            where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var authorizationAttributes = request.GetType()
            .GetCustomAttributes<AuthorizeAttribute>()
            .ToList();

        next.ThrowIfNull();

        if (authorizationAttributes.Count == 0)
        {
            return await next().ConfigureAwait(false);
        }

        var requiredPermissions =
            authorizationAttributes.SelectMany(
                authorizationAttribute => authorizationAttribute.Permissions?.Split(',') ?? []).ToList();

        var requiredPolicies =
            authorizationAttributes.SelectMany(
                authorizationAttribute => authorizationAttribute.Policies?.Split(',') ?? []).ToList();

        var requiredRoles =
            authorizationAttributes.SelectMany(
                authorizationAttribute => authorizationAttribute.Roles?.Split(',') ?? []).ToList();

        var authorizationResult = authorizationService.AuthorizeCurrentUser(
            request,
            requiredRoles,
            requiredPermissions,
            requiredPolicies);

        return authorizationResult.IsError
            ? (dynamic)authorizationResult.Errors
            : await next().ConfigureAwait(false);
    }
}