using EduMentorAI.Application.Dtos;
using EduMentorAI.Application.Dtos.Auth;
using MediatR;

namespace EduMentorAI.Application.Features.Auth.Commands;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<ApiResponse<LoginResponseDto>>;