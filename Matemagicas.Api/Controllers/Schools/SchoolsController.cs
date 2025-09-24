using Matemagicas.Application.Schools.DataTransfer.Requests;
using Matemagicas.Application.Schools.DataTransfer.Responses;
using Matemagicas.Application.Schools.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Schools;

[ApiController]
[Route("api/schools")]
public class SchoolsController(ISchoolsAppService schoolsAppService) : ControllerBase
{
    /// <summary>
    /// Creates a School
    /// </summary>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPost]
    public async Task<ActionResult<SchoolResponse>> CreateAsync([FromBody] SchoolCreateRequest request) =>
        await schoolsAppService.CreateAsync(request);

    /// <summary>
    /// Retrieves a School based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>GameResponse</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SchoolResponse>> GetByIdAsync(string id) =>
        await schoolsAppService.GetByIdAsync(id);
}