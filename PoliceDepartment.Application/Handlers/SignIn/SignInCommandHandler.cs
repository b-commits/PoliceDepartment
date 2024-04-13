using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Security;
using PoliceDepartment.Core.Exceptions;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Handlers.SignIn;

[UsedImplicitly]
internal sealed class SignInCommandHandler : IRequestHandler<SignInCommand, JwtDto>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IAuthenticator _authenticator;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<SignInCommandHandler> _logger;

    public SignInCommandHandler(
        IPasswordManager passwordManager, 
        IAuthenticator authenticator, 
        IUserRepository userRepository, 
        ILogger<SignInCommandHandler> logger)
    {
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<JwtDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var securedPassword = _passwordManager.Secure(request.Password);
        
        var isPasswordValid = _passwordManager.Validate(request.Password, securedPassword);

        if (!isPasswordValid)
        {
            _logger.LogError("Invalid password provided for user '{email}'", request.Email);
            throw new InvalidPasswordException();
        }
   
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            _logger.LogError("User with email '{email}' could not be found.", request.Email);
            throw new InvalidUsernameException(request.Email);
        }
        
        var token = _authenticator.CreateToken(user.Email, user.Role.ToString());
        
        return token;
    }
}