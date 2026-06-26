using EduMentorAI.Application.Features.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduMentorAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var response = await _mediator.Send(new GetStudentsQuery());
        return Ok(response);
    }
}