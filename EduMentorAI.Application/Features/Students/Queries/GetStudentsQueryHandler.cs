using EduMentorAI.Application.Dtos;
using EduMentorAI.Application.Interfaces;
using EduMentorAI.Domain.Entities;
using MediatR;

namespace EduMentorAI.Application.Features.Students.Queries;

internal sealed class GetStudentsQueryHandler
    : IRequestHandler<GetStudentsQuery, ApiResponse<IReadOnlyList<StudentDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStudentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<IReadOnlyList<StudentDto>>> Handle(
        GetStudentsQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<Student> students = await _unitOfWork
            .Repository<Student>()
            .GetAllAsync();

        List<StudentDto> response = new();

        foreach (Student student in students)
        {
            response.Add(new StudentDto
            {
                Id = student.Id,
                StudentCode = student.StudentCode,
                AdmissionYear = student.AdmissionYear,
                FullName = student.User.FullName,
                Email = student.User.Email
            });
        }

        return new ApiResponse<IReadOnlyList<StudentDto>>(
            true,
            "Estudiantes obtenidos correctamente.",
            response);
    }
}
