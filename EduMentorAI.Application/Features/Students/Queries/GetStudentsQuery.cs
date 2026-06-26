using EduMentorAI.Application.Dtos;
using MediatR;

namespace EduMentorAI.Application.Features.Students.Queries;

public sealed record GetStudentsQuery : IRequest<ApiResponse<IReadOnlyList<StudentDto>>>;