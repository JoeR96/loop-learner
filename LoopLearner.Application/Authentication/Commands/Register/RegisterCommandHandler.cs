using CSharpFunctionalExtensions;
using LoopLearner.Application.Contracts.Persistence;
using LoopLearner.Application.Contracts.Services;
using LoopLearner.Application.Extensions;
using LoopLearner.Domain.Errors;
using LoopLearner.Domain.Errors.Authentication;
using LoopLearner.Domain.Errors.General;
using LoopLearner.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;

namespace LoopLearner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IJwtGenerator jwtGenerator,
    IUserRepository userRepository,
    IPasswordHasher<User> passwordHasher)
    : IRequestHandler<RegisterCommand, Result<AuthenticationResponse, Error>>
{
    public async Task<Result<AuthenticationResponse, Error>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Result<bool, ValidationError> validationResult = await request.ValidateAsync(new RegisterCommandValidator(), cancellationToken);
        if (validationResult.IsFailure)
            return validationResult.Error;


        if (await userRepository.GetUserByEmailAsync(request.Email) != null)
        {
            return new EmailAlreadyInUseError();
        }
        if (await userRepository.GetUserByUserNameAsync(request.UserName) != null)
        {
            return new UserNameAlreadyTakenError();
        }

        User user = User.CreateNew(request.FirstName, request.LastName, request.UserName, request.Email, request.Password);
        string hashedPassword = passwordHasher.HashPassword(user, request.Password);
        user.UpdatePassword(hashedPassword);

        userRepository.AddUser(user);
        await userRepository.SaveChangesAsync();

        string token = jwtGenerator.CreateToken(user);
        return new AuthenticationResponse(user, token);
    }
}