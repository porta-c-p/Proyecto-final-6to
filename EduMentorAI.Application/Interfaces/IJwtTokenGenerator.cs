namespace EduMentorAI.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        int userId,
        string fullName,
        string email,
        string role);
}