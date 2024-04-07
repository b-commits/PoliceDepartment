using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.SignIn;

[UsedImplicitly]
internal sealed class SignInCommandHandler : IRequestHandler<SignInCommand, JwtDto>
{
    private readonly IPasswordManager passwordManager;
    private readonly IAuthenticator authenticator;
    private readonly IUserRepository userRepository;
    private readonly ILogger logger;

    public SignInCommandHandler(
        IPasswordManager passwordManager, 
        IAuthenticator authenticator, 
        IUserRepository userRepository, 
        ILogger logger)
    {
        this.passwordManager = passwordManager;
        this.authenticator = authenticator;
        this.userRepository = userRepository;
        this.logger = logger;
    }

    public async Task<JwtDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = passwordManager.Secure(request.email);
        
        var isPasswordValid = passwordManager.Validate(request.email, securedPassword);

        if (!isPasswordValid)
        {
            logger.LogError("Invalid password provided for user '{email}'", request.username);
            throw new InvalidPasswordException();
        }
   
        var user = await userRepository.GetUserByEmailAsync(request.email);
        var token = authenticator.CreateToken(user.Email, user.Role.ToString());
        

        return token;
    }
}