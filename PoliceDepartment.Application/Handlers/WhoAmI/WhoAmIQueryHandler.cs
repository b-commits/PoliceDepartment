using JetBrains.Annotations;
using MediatR;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.WhoAmI;

[UsedImplicitly]
internal sealed class WhoAmIQueryHandler(ICurrentUserService currentUserService) : IRequestHandler<WhoAmIQuery, User?>
{
    public async Task<User?> Handle(WhoAmIQuery request, CancellationToken cancellationToken)
    {
        return await currentUserService.GetAsync();
    }
}