namespace EduMentorAI.Application.Dtos;

public sealed class StudentDto
{
    public int Id { get; init; }
    public string StudentCode { get; init; } = string.Empty;
    public int AdmissionYear { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}