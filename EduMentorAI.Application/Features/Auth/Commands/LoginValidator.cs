using FluentValidation;

namespace EduMentorAI.Application.Features.Auth.Commands;

public sealed class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress()
            .WithMessage("El correo electrónico no tiene un formato válido.");

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage("La contraseña es obligatoria.")
            .MinimumLength(6)
            .WithMessage("La contraseña debe tener como mínimo 6 caracteres.");
    }
}