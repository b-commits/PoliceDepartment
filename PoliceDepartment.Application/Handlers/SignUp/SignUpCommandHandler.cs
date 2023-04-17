using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Application.Utilities;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.SignUp;

internal sealed class SignUpCommandHandler : IRequestHandler<SignUpCommand>
{
    private readonly IPasswordManager passwordManager;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly Logger<SignUpCommandHandler> logger;

    public SignUpCommandHandler(
        IDateTimeProvider dateTimeProvider, 
        Logger<SignUpCommandHandler> logger, 
        IPasswordManager passwordManager)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.logger = logger;
        this.passwordManager = passwordManager;
    }

    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.Password);
        
        var user = new User(request.UserId, request.Email, securedPassword, 
            request.Password, request.Role, dateTimeProvider.UtcNow.Date);
        
        logger.LogInformation("Created user {email}.", request.Email);
    }
}