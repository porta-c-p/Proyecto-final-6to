using EduMentorAI.Application.Dtos;
using EduMentorAI.Application.Dtos.Auth;
using EduMentorAI.Application.Interfaces;
using EduMentorAI.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EduMentorAI.Application.Features.Auth.Commands;

internal sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, ApiResponse<LoginResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IValidator<LoginCommand> _validator;

    public LoginCommandHandler(
        IUnitOfWork unitOfWork,
        IJwtTokenGenerator jwtTokenGenerator,
        IValidator<LoginCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenGenerator = jwtTokenGenerator;
        _validator = validator;
    }

    public async Task<ApiResponse<LoginResponseDto>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            string message = validationResult.Errors.First().ErrorMessage;

            return new ApiResponse<LoginResponseDto>(
                false,
                message,
                null);
        }

        User? user = await _unitOfWork
            .Repository<User>()
            .FirstOrDefaultAsync(user =>
                user.Email == request.Email &&
                user.IsActive == true);

        if (user is null)
        {
            return new ApiResponse<LoginResponseDto>(
                false,
                "El usuario no existe o está inactivo.",
                null);
        }

        bool passwordIsValid = BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash);

        if (!passwordIsValid)
        {
            return new ApiResponse<LoginResponseDto>(
                false,
                "Las credenciales ingresadas son incorrectas.",
                null);
        }

        Role? role = await _unitOfWork
            .Repository<Role>()
            .GetByIdAsync(user.RoleId);

        if (role is null)
        {
            return new ApiResponse<LoginResponseDto>(
                false,
                "El usuario no tiene un rol válido asignado.",
                null);
        }

        string token = _jwtTokenGenerator.GenerateToken(
            user.Id,
            user.FullName,
            user.Email,
            role.Name);

        LoginResponseDto response = new()
        {
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = role.Name,
            Token = token
        };

        return new ApiResponse<LoginResponseDto>(
            true,
            "Inicio de sesión exitoso.",
            response);
    }
}